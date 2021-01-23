    [Serializable()]
    [XmlRoot("component", Namespace="", IsNullable=false)]
    public partial class CT_Component 
    {
        [XmlAttribute("name")]
        public string Name { get; set;}
    }
    [Serializable()]
    [XmlRoot("composite", Namespace="", IsNullable=false)]
    public partial class CT_Composite 
    {
        [XmlElement("component", typeof(CT_Component))]
        [XmlElement("composite", typeof(CT_Composite))]
        public object[] Items { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
