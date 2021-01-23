    [XmlRoot("root")]
    public class Root
    {
        [XmlElement("rating")]
        public Rating[] Ratings { get; set; }
    }
    public class Rating
    {
        [XmlAttribute("city")]
        public string City { get; set; }
        [XmlAttribute("code")]
        public string Code { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
