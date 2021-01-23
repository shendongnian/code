      [XmlRoot("example")]
      public class Example {
         [XmlElement("id")]
         public int Id { get; set;}
         [XmlElement("messages")]
         public Message messages {get; set;}
      }
      [XmlRoot("messages")]
      public class Messages {
         [XmlElement("message")]
         public List<Message> message { get; set;}
         
      }
      [XmlRoot("message")]
      public class Message {
         [XmlElement("words")]
         public string Words { get; set;}
         
      }​
