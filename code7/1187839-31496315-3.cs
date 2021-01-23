    [XmlRoot("person")]
    public class Person
    {
        [XmlElement("last-name")]
        public string LastName { get; set; }
        [XmlElement("first-name")]
        public string FirstName { get; set; }
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "last-changed-on")]
        public XmlDateTime LastChangedOn { get; set; }
    }
