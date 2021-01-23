    [XmlRoot(ElementName = "rdlt", Namespace = "http://www.rdlt.org")]
    public class Container
    {
        [XmlElement(ElementName = "created", Namespace = "http://www.rdlt.org")]
        public string Created { get; set; }
        [XmlElement(ElementName = "updated", Namespace = "http://www.rdlt.org")]
        public string Updated { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "rdlt", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string _rdlt { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
