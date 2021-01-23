    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class steps
    {
        public script script { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("step")]
        public List<step> step { get; set; }
    }
    
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class step
    {
        [System.Xml.Serialization.XmlElementAttribute("step")]
        public List<step> Step1 { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("comp")]
        public List<comp> comp { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { get; set; }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class comp
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dir { get; set; }
    }
