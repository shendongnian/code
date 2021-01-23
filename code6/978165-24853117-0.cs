    public class Message
    {
        public string level { get; set; }
        public string key { get; set; }
        public string dsc { get; set; }
    }
    
    public class RootObject
    {
        public string status { get; set; }
        public List<Message> messages { get; set; }
    }
