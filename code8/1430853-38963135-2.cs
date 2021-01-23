    public class data
    {
        [XmlElement("myassembly")]
        public MyAssembly myassembly { get; set; }
    }
    public class MyAssembly
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("folder")]
        public string folder { get; set; }
        [XmlElement("myassembly")]
        public MyAssembly[] myassembly { get; set; }
    }
