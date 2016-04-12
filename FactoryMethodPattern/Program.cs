using System;
namespace Factory
{
    /// <summary>
    /// The 'Product' interface
    /// </summary>
    public interface IFactory
    {
        void Drive(int miles);
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Scooter : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Scooter : " + miles.ToString() + "miles");
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Bike : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Bike : " + miles.ToString() + "miles");
        }
    }

    public class Driver
    {
        public string Name { get; set; }

        public IFactory DriverVehicle { get; set; }
    }

    public class Car : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the car: {0}miles", miles);
        }
    }

    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public abstract class VehicleFactory
    {
        public abstract IFactory GetVehicle(string Vehicle);

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IFactory GetVehicle(string Vehicle)
        {
            switch (Vehicle)
            {
                case "Scooter":
                    return new Scooter();
                case "Bike":
                    return new Bike();
                case "Car":
                    return new Car();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }

    }

    /// <summary>
    /// Factory Pattern Demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory factory = new ConcreteVehicleFactory();
            Driver mark = new Driver
            {
                Name = "mark",
                DriverVehicle = factory.GetVehicle("Car")
            };

            mark.DriverVehicle.Drive(2);

            while(true)
            {
                Console.Write("What do you want to drive next? ");
                mark.DriverVehicle = factory.GetVehicle(Console.ReadLine());
                mark.DriverVehicle.Drive(4);
            }


            //IFactory scooter = factory.GetVehicle("Scooter");
            //scooter.Drive(10);

            //IFactory bike = factory.GetVehicle("Bike");
            //bike.Drive(20);
            

        }
    }
}