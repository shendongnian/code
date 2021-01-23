    public class Master
    {
        [XmlType(AnonymousType = true)]
        [XmlRoot(Namespace = "", IsNullable = false)]
        public partial class directory
        {
            [XmlElement("ContactDirectory")]
            public directoryContactDirectory[] ContactDirectory { get; set; }
        }
        [XmlType(AnonymousType = true)]
        public partial class directoryContactDirectory
        {
            public directoryContactDirectoryPerson Person { get; set; }
            [XmlAttribute()]
            public string name { get; set; }
        }
        [XmlType(AnonymousType = true)]
        public partial class directoryContactDirectoryPerson
        {
            [XmlAttribute()]
            public string name { get; set; }
            [XmlAttribute()]
            public string number { get; set; }
        }
    }
