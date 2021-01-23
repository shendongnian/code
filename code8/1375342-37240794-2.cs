    [XmlRoot("Namespace")
    public class Namespace
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        
        [XmlArray("Metrics")]
        [XmlArrayItem("Metric")]
        public List<Metric> Metrics { get; set; }
        [XmlArray("Types")]
        [XmlArrayItem("Type")]
        public List<MetricType> Types { get; set; }
    }
