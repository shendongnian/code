    [XmlRoot(ElementName = "S3")]
    public class S3
    {
        [XmlAttribute(AttributeName = "C")]
        public string C { get; set; }
    }
    [XmlRoot(ElementName = "S2")]
    public class S2
    {
        [XmlElement(ElementName = "S3")]
        public List<S3> S3 { get; set; }
        [XmlAttribute(AttributeName = "B")]
        public string B { get; set; }
    }
    [XmlRoot(ElementName = "S1")]
    public class S1
    {
        [XmlElement(ElementName = "S2")]
        public List<S2> S2 { get; set; }
        [XmlAttribute(AttributeName = "A")]
        public string A { get; set; }
    }
    [XmlRoot(ElementName = "body")]
    public class Body
    {
        [XmlElement(ElementName = "S1")]
        public List<S1> S1 { get; set; }
    }
