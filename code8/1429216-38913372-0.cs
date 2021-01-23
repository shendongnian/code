    [XmlRoot("item")]
    public class Item
    {
        [XmlElement("name")]
        public string Name { get; set; }
    
        [XmlElement("description")]
        public string Description { get; set; }
    
        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public List<string> Categories { get; set; }
    
        [XmlArray("children")]
        [XmlArrayItem("child")]
        public List<Child> Children { get; set; }
    }
    
    public class Child
    {
        [XmlElement("description")]
        public string Description { get; set; }
    
        [XmlElement("origin")]
        public string Origin { get; set; }
    
        [XmlAnyElement("other")]
        public XmlElement Other { get; set; }
    }
