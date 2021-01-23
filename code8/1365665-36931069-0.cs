    public class SerializationClass
    {
        public City City { get; set; }
    }
    public class City
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
