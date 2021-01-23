    public class Option
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public Decimal Amount { get; set; }
    }
