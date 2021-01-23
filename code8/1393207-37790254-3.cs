    public class SolarSystem 
    { 
        public Dictionary<string, Planet> Planets { get; } = new Dictionary<string, Planet>();
        public SolarSystem()
        {
            Planets.add('Mercury', new Planet());
            Planets.add('Venus', new Planet());
            // etc...
        }
    }
