    public class Root
    {
        [XmlElement("ItemGroup")]
        public List<ItemGroup> ItemGroups { get; set; }
    }
    public class ItemGroup
    {
        [XmlElement("Reference")]
        public List<ReferenceOrCompile> References { get; set; }
        [XmlElement("Compile")]
        public List<ReferenceOrCompile> Compiles { get; set; }
    }
    public class ReferenceOrCompile
    {
        [XmlAttribute("Include")]
        public string Include { get; set; }
    }
