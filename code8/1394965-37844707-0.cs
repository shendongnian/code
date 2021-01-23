    [XmlRoot(ElementName = "PROPERTY")]
    public class PROPERTY
    {
        [XmlAttribute(AttributeName = "NAME")]
        public string NAME { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    
    [XmlRoot(ElementName = "ITEM")]
    public class ITEM
    {
        [XmlElement(ElementName = "PROPERTY")]
        public List<PROPERTY> PROPERTY { get; set; }
    }
    
    [XmlRoot(ElementName = "OBJECT")]
    public class OBJECT
    {
        [XmlElement(ElementName = "ITEM")]
        public List<ITEM> ITEM { get; set; }
        [XmlAttribute(AttributeName = "TYPE")]
        public string TYPE { get; set; }
    }
    
    [XmlRoot(ElementName = "DATA")]
    public class DATA
    {
        [XmlElement(ElementName = "OBJECT")]
        public List<OBJECT> OBJECT { get; set; }
    }
