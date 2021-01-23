    abstract class vehicle
    {
    
        vehicle() {   }
    
        public abstract string Model { get; }
    
    }
    
    
    // Inherited classes
    class tesla : vehicle
    {
        private readonly string model = "Model S";      // This is unchanging
    
        public override string Model { get { return model; }}
    }
    
    class ferrari : vehicle
    {
    
        public override string Model { get { return "458 Spider"; }}
    
    }
