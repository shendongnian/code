    void Main()
    {
        
        var vehicles = new List<Vehicle>();
        
        for (int i = 0; i < 10; i++)
        {
            vehicles.Add(new Vehicle());
        }
    
        vehicles.OrderBy(vehicle => vehicle.VehicleType.VehicleTypeID)
                .GroupBy(vehicleType => vehicleType.VehicleType.VehicleTypeID, vehicle => vehicle.ODO_Reading, (id, odo) => new {Ids = id, Odo = odo});
    }
    
    public class Vehicle
    {
        public Vehicle()
        {
            this.VehicleType = new VehicleType();
            this.ODO_Reading = random.Next(100, 100000);
        }
    
        public VehicleType VehicleType { get; set;  }
        public int ODO_Reading { get; set; }
    }
    
    public class VehicleType
    {
        public VehicleType()
        {
            VehicleTypeID = random.Next(1, 10);
        }
        
        public int VehicleTypeID{ get; set; }
    } 
    
    public static Random random = new Random();
