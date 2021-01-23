    [XmlRoot(ElementName = "data")]
    public class Data
    {
        [XmlArray("data")]
        [XmlArrayItem("objectClass")]
        public List<objectClass> ObjectItemList { get; set; }
    }
