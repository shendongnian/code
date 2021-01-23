    public class Request
    {
        public int order_id { get; set; }
        public string action { get; set; }
    }
    
    public class RootObject
    {
        public int channel_id { get; set; }
        public List<Request> requests { get; set; }
    }
