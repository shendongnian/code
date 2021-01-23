    [Serializable()]
    public class add
    {
        [System.Xml.Serialization.XmlAttribute("Path")]
        public string Path { get; set; }
        [System.Xml.Serialization.XmlAttribute("TemplateId")]
        public string TemplateId { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("pathsSettings")]
    public class pathsSettings
    {
        [XmlArray("paths")]
        [XmlArrayItem("add", typeof(add))]
        public add[] paths { get; set; }
    }
