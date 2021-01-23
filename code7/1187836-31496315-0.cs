    [XmlRoot("person")]
    public class Person
    {
        [XmlElement("last-name")]
        public string LastName { get; set; }
        [XmlElement("first-name")]
        public string FirstName { get; set; }
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement(DataType = "dateTime", ElementName = "last-changed-on")]
        public DateTime LastChangedOn { get; set; }
    }
