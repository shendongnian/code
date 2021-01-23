    public interface IVehicle
    {
        string Type { get; }
    }
    public class Vehicle: IVehicle
    {
        public string Type { get; }
    }
    public class Jeep : Vehicle
    {
    }
