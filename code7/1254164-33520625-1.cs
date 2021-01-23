    void Main()
    {
        
        var vehicles = new List<Vehicle>();
        
        for (int i = 0; i < 10; i++)
        {
            vehicles.Add(new Vehicle());
        }
    
        vehicles.OrderBy(vehicle     => vehicle.VehicleType.VehicleTypeID)
                .GroupBy(vehicleType => vehicleType.VehicleType.VehicleTypeID, 
                         vehicle     => vehicle.ODO_Reading, 
                                        (vehicleTypeID, minRunVehicle) => new 
                                        {
                                            VehicleTypeId = vehicleTypeID, 
                                            minRunVehicle = minRunVehicle
                                        })
                .ToList()
                .ForEach(vehicle => 
                         {
                             Console.WriteLine(vehicle.VehicleTypeId);
                             vehicle.minRunVehicle.ToList()
                                                  .ForEach(minRun =>
                                                  {
                                                      Console.WriteLine ("\t > :" + minRun);
                                                  });
                             Console.WriteLine ("\n");
                         });
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
        
        public int VehicleTypeID { get; set; }
    } 
    
    public static Random random = new Random();
