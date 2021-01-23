    [XmlType(AnonymousType = true)]
    [XmlRoot("Amendment.Text", Namespace = "", IsNullable = false)]
    public partial class AmendmentText
    {        
        [XmlElement("Bold", typeof(string))]
        [XmlElement("Italic", typeof(string))]
        [XmlElement("Line", typeof(byte))]
        [XmlElement("Page", typeof(byte))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items { get; set; }
                
        [XmlElement("ItemsElementName")]
        [XmlIgnore()]
        public ItemsChoiceType[] ItemsElementName { get; set; }
        
    }
    
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType
    {        
        Bold,
        Italic,
        Line,
        Page,
    }
