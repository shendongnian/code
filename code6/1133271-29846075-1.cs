    public class Passengers
    {
        public string kind { get; set; }
        public int? adultCount { get; set; }
        public int? childCount { get; set; }
        public int? infantInLapCount { get; set; }
        public int? infantInSeatCount { get; set; }
        public int? seniorCount { get; set; }
    }
    
    public class PermittedDepartureTime
    {
        public string kind { get; set; }
        public string earliestTime { get; set; }
        public string latestTime { get; set; }
    }
    
    public class Slouse
    {
        public string kind { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string date { get; set; }
        public int? maxStops { get; set; }
        public int? maxConnectionDuration { get; set; }
        public string preferredCabin { get; set; }
        public PermittedDepartureTime permittedDepartureTime { get; set; }
        public List<string> permittedCarrier { get; set; }
        public string alliance { get; set; }
        public List<string> prohibitedCarrier { get; set; }
    }
    
    public class Request
    {
        public Passengers passengers { get; set; }
        public List<Slouse> slice { get; set; }
        public string maxPrice { get; set; }
        public string saleCountry { get; set; }
        public bool? refundable { get; set; }
        public int? solutions { get; set; }
    }
    
    public class RootObject
    {
        public Request request { get; set; }
    }
