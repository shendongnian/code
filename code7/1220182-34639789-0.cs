    public class DroneDto
    {
        public int iddrones {get;set;}
        public static DroneDto CreateFromEntity(DroneEntity dbEntity)
        {
            return new DroneDto
            {
                iddrones = dbEntity.iddrones,
                ...
            }
        }
    }
