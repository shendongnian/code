    [Serializable]
    public class MotorBike
    {
    
    }
    
    [Serializable]
    public class Sedan
    {
        public float fuel;
    }
    
    [Serializable]
    public class Cars
    {
        public List<Sedan> sedan;
    
        public Cars()
        {
            sedan = new List<Sedan>();
        }
    }
    
    [Serializable]
    public class Vehicles
    {
        public Cars cars;
        public MotorBike motorBike;
    
        public Vehicles()
        {
            cars = new Cars();
            motorBike = new MotorBike();
        }
    }
