    public class Planet 
    {
        public double distanceFromEarth { get; set; }
        public int orbitTimeInDays { get; set; }
        public string name {get; set;}
        // etc...
        public Planet() { }
    }
    public class SolarSystem 
    { 
        public List<Planet> planets {get; private set;}
        public SolarSystem()
        {
            planets = new List<Planet>();
            planets.Add( new Planet { name = "mercury", distanceFromEarth = 23456 });
            planets.Add( new Planet { name = "venus", distanceFromEarth = 12456 });
        }
    }
    static void Main(string[] args)
    {
        SolarSystem solarSystem = new SolarSystem();
        foreach (Planet planet in solarSystem.planets)
        {
            Console.WriteLine("Time taken to orbit sun (in days) : " + planet.orbitTimeInDays.ToString());
        }
    }
