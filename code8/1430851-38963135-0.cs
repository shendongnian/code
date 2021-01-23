    public class data
    {
        [XmlElement("myassembly")]
        public MyAssembly myassembly;
    }
    public class MyAssembly
    {
        [XmlAttribute("name")]
        public string name;
        [XmlAttribute("folder")]
        public string folder;
        [XmlElement("myassembly")]
        public MyAssembly[] myassembly;
    }
