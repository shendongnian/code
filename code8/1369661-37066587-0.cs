    [XmlRoot(ElementName = "data")]
    public class Data
    {
        [XmlElement(ElementName = "objectClass")]
        public List<objectClass> ObjectItemList { get; set; }
    }
