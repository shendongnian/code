    public class messages
    {
        public string accountreference { get; set; }
        public string from { get; set; }
        [XmlElement("message")]
        public List<message> messageList { get; set; }
    }
    public class message
    {
        public string to { get; set; }
        public string body { get; set; }
    }
