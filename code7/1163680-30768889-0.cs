    using System.Xml.Serialization;
    
    [XmlRoot(ElementName = "users")]
    public class Users : List<User>
    {
    
    }
    
    [XmlType(TypeName = "user")]
    public class User
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    
        [XmlAttribute(AttributeName = "age")]
        public int Age { get; set; }
    
        [XmlText]
        public string Name { get; set; }
    }
