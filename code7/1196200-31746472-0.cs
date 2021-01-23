    [XmlRoot(ElementName = "FooBars", Namespace = "http://foos")]
    public class FooBars
    {
        [XmlElement(ElementName = "Id1", Namespace = "http://bars")]
        public string Id1 { get; set; }
        [XmlElement(ElementName = "Id2", Namespace = "http://bars")]
        public string Id2 { get; set; }
        [XmlArray(ElementName = "Info", Namespace = "http://bars"), XmlArrayItem("Data")] //<--
        public List<Data> Info { get; set; }
    }
