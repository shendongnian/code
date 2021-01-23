    [Serializable()]
    public class myObject
    {
        [XmlElement("someProperty")]
        public string someProperty { get; set; }
        [XmlArray("mySubObjects")]
        [XmlArrayItem("mySubObject", typeof(string))]
        public List<string> mySubObjects { get; set; }
    }
