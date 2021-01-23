    [XmlRoot(ElementName = "rdlt", Namespace = "http://www.rdlt.org")]
    public class Container
    {
        [XmlElement(ElementName = "created", Namespace = "http://www.rdlt.org")]
        public string Created { get; set; }
        [XmlElement(ElementName = "updated", Namespace = "http://www.rdlt.org")]
        public string Updated { get; set; }
    }
