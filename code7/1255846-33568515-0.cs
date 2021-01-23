    [XmlInclude(typeof(DataA))]
    [XmlInclude(typeof(DataB))]
    public class Data
    {
        [XmlElement("Name")]
        public string Name { get; set; }
    }
