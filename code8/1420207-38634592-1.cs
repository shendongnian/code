    public class Sender
    {
       public string id { get; set; }
    }
    public class Recipient
    {
        public string id { get; set; }
    }
    public class Message
    {
        public string mid { get; set; }
        public int seq { get; set; }
        public string text { get; set; }
    }
    public class Messaging
    {
        public Sender sender { get; set; }
        public Recipient recipient { get; set; }
        public long timestamp { get; set; }
        public Message message { get; set; }
    }
    public class Entry
    {
        public List<Messaging> messaging { get; set; }
    }
    public class RootObject
    {
         public List<Entry> entry { get; set; }
    }
