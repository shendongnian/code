    [XmlRoot(ElementName = "claim")]
    public class ClaimText
    {
        [XmlAttribute]
        public string id;
        [XmlAttribute]
        public string num;
        [XmlElement(ElementName = "claim-text")]
        public ClaimInnerContents contents;
    }
    public class ClaimInnerContents
    {
        [XmlElement(ElementName = "claim-ref", Type = typeof(ClaimRef))]
        [XmlText(Type = typeof(string))]
        public object[] contents;
    }
    public class ClaimRef
    {
        [XmlAttribute]
        public string idref;
        [XmlText]
        public string text;
    }
