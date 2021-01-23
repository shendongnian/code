    [Serializable, XmlRoot("Entry")]
    public class DeserializedClass
    {
        public string entryValue1;
        public string entryValue2;
        [XmlElement("RootElement")]
        public List<RootElement> rootElement { get; set; }
    }
    public class RootElement
    {
        public string rootElementValue1 { get; set; }
        public string rootElementValue2 { get; set; }
    }
