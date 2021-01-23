    [XmlRoot("example")]
    public class Example
    {
         [XmlElement("id")]
         public int Id { get; set; }
         [XmlElement("messages")]
         public Messages Messages { get; set; }
    }
    public class Messages
    {
        [XmlElement("message")]
        public List<Message> Message { get; set; }
    }
    public class Message
    {
        [XmlElement("words")]
        public string Words { get; set; }
    }
