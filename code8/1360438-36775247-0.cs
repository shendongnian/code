    public class AdditionalConfig
    {
        [XmlAnyAttribute]
        public XmlAttribute[] attributes;
        [XmlAnyElement]
        public XmlElement[] elements;
    }
    
    public class MyClass
    {
        public string AValue { get; set; }
        public AdditionalConfig AdditionalConfig { get; set; }
    }
