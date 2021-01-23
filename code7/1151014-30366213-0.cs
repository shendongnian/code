    [XmlRoot("event")]
    public class EventResult
    {
        [XmlElement("property1")]
        public ulong Property1 { get; set; }
        [XmlElement("property2")]
        public int Property2 { get; set; }
        [XmlElement("class1", typeof(class1))]
        [XmlElement("class2", typeof(class2))]
        [XmlElement("class3", typeof(class3))]
        public Object EventType { get; set; }
    }
