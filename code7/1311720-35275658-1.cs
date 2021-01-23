    [XmlRootAttribute("ApplicationToRun")]
    public class MyXMLClass
    {
        [XmlAttribute]
        public bool IsFromXML { get; set; }
        [XmlArray("Apps")]
        [XmlArrayItem("FullPath")]
        public string[] fullPath { get; set; }
    }
