    [XmlType(AnonymousType = true)]
    [XmlRoot("Amendment.Text", Namespace = "", IsNullable = false)]
    public partial class AmendmentText
    {
        [XmlElement("Line", typeof(int))]
        public int Line { get; set; }
        [XmlElement("Page", typeof(int))]
        public int Page { get; set; }
        [XmlElement("Bold", typeof(string))]        
        [XmlElement("Italic", typeof(string))]        
        [XmlChoiceIdentifier("ContentName")]
        public object[] Content { get; set; }
        [XmlElement("ContentName")]
        [XmlIgnore()]
        public ContentName[] ContentName { get; set; }
        
    }
    
    [XmlType(IncludeInSchema = false)]
    public enum ContentName
    {        
        Bold,
        Italic,        
    }
