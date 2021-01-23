    public class Vehicle
    {
        public Vehicle()
        {
        }
        public int NumberOfWheels { get; set; }
    }
    public class Car : Vehicle
    {
        public Car() : base()
        {
            NumberOfWheels = 4;
        }
    }
    public class Motorbike : Vehicle
    {
        public Motorbike() : base()
        {
            NumberOfWheels = 2;
        }
    }
