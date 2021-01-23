    public class Flight
    {
        public string From { get; set; }
        public string To { get; set; }
    
        // Sub routes
        public List<Flight> Flights { get; set; }
    }
