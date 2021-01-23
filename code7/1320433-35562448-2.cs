    public class Stay
    {
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public string shiftDays { get; set; }
    }
    
    public class Pax
    {
        public string type { get; set; }
        public int age { get; set; }
    }
    
    public class Occupancy
    {
        public int rooms { get; set; }
        public int adults { get; set; }
        public int children { get; set; }
        public List<Pax> paxes { get; set; }
    }
    
    public class Geolocation
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
        public int radius { get; set; }
        public string unit { get; set; }
    }
    
    public class RootObject
    {
        public Stay stay { get; set; }
        public List<Occupancy> occupancies { get; set; }
        public Geolocation geolocation { get; set; }
    }
