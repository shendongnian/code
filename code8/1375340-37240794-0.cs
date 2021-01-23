    public class Namespace
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlArrayItem("Type")]
        public List<MetricType> Types { get; set; }
    }
