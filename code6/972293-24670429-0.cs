    public EmailDetails To {get;set;}
    public EmailDetails From {get;set;}
    ...
    public class EmailDetails {
        [XmlAttribute]
        public EmailType EmailType {get;set;}
        [XmlText]
        public string Address {get;set;}
    }
