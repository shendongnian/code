    [XmlInclude(typeof(DataA))]
    [XmlInclude(typeof(DataB))]
    [XmlRoot("Data", Namespace = Data.XmlDefaultNameSpace)]
    public class Data
    {
        public const string XmlDefaultNameSpace = "http://www.stackoverflow.com/xsd/Data";
    
        [XmlElement("Name")]
        public string Name { get; set; }
    }
