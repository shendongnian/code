    public class Resource
    {
        [XmlAttribute("name")]
        public string m_Name { get; set; }
    
        [XmlArrayItem("value")]
        public string[] ItemDrop;
    }
