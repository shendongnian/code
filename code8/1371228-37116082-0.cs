    [XmlRoot(ElementName="step")]
    public class Step 
    {
        [XmlElement(ElementName="comp")]
        public Comp Comp { get; set; }
        [XmlAttribute(AttributeName="name")]
        public string Name { get; set; }
        [XmlElement(ElementName="step")]
        public Step SubStep { get; set; } // <-- Change this to something else like "SubStep"
    }
