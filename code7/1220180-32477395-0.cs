    var drone = db.drones.Select(d => DroneDto.FromDb(d))
                         .Where(drones => drones.iddrones == id);
    
    public class DroneDto
    {
        public int iddrones {get;set;}
        // ...other props
        
        public static DroneDto FromDb(DroneEntity dbEntity)
        {
             return new DroneDto
             {
                 iddrones = dbEntity.iddrones,
                 //... other props
             }
        }
    }
