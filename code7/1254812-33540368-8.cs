    public abstract class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
    }
    public class Car : Vehicle { public string CarSpecificProperty { get; set; } }
    public class Truck : Vehicle { public string TruckSpecificProperty { get; set; } }
    public abstract class Driver<TVehicle> where TVehicle : Vehicle
    {
        public virtual TVehicle Vehicle { get; set; }
    }
    public class CarDriver : Driver<Car> {}
    public class TruckDriver : Driver<Truck> {}
