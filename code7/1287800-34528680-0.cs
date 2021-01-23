    public class messages
    {
        public string accountreference { get; set; }
    
        public string from { get; set; }
    
        public List<message> message { get; set; }
    }
    
    public class message
    {
        public string to { get; set; }
    
        public string body { get; set; }
    }
