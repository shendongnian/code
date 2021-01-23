    public class Namespace
    {
        [XmlAttribute]
        public string Name { get; set; }
        public List<Metric> Metrics { get; set; }
        [XmlArrayItem("Type")]
        public List<MetricType> Types { get; set; }
    }
