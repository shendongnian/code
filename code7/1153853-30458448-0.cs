    [XmlRoot("xml")]
    public class ClassCollection
    {
        [XmlArray("classes")]
        [XmlArrayItem("class", typeof(SingleClass))]
        public SingleClass[] singleClass { get; set; }
    }
    public class SingleClass
    {
        [XmlElement("attribute")]
        public List<Attribute> Attributes { get; set; }
    
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
    public class Attribute {
        [XmlAttribute("name")]
        public string name { get; set; }
    
        [XmlAttribute("type")]
        public string type { get; set; }
    }
