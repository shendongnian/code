    public abstract class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
    }
    public class Car : Vehicle { public string CarSpecificProperty { get; set; } }
    public class Truck : Vehicle { public string TruckSpecificProperty { get; set; } }
    public abstract class Driver
    {
        public int Id { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
    public class CarDriver : Driver
    {
        public Car Car
        {
            get { return this.Vehicle as Car; }
            set { this.Vehicle = value as Car; }
        }
    }
    public class TruckDriver : Driver
    {
        public Truck Truck
        {
            get { return this.Vehicle as Truck; }
            set { this.Vehicle = value as Truck; }
        }
    }
