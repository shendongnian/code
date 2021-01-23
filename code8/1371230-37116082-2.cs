    [XmlRoot(ElementName="step")]
    public class Step 
    {
        [XmlElement(ElementName="comp")]
        public Comp Comp { get; set; }
        [XmlAttribute(AttributeName="name")]
        public string Name { get; set; }
        [XmlElement(ElementName="steps")]
        public List<Step> Steps { get; set; }
    }
