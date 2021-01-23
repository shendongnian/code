    public class CorvilTest
    {
        [ElasticProperty(Name = "@message")]
        public Message Message { get; set; }
        /* Other properties if any */
    }
    public class Message
    {
        [ElasticProperty(Name = "eventName")]
        public string EventName { get; set; }
    }
    
    
