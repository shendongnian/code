    public abstract class Vehicle
    {
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public VehicleInfo VehicleInfo { get; set; }
    }
    public class CarVehicle : Vehicle
    { }
    public class BikeVehicle : Vehicle
    { }
    
    public abstract class VehicleInfo
    {
        public int ID { get; set; }
    }
    public class CarInfo : VehicleInfo
    {
        public string Model { get; set; }
    }
    public class BikeInfo : VehicleInfo
    {
        public bool IsEbike { get; set; }
    }
