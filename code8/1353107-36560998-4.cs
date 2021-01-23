    [XmlRoot(ElementName = "Sitecolumn")]
    public class Sitecolumn
    {
        [XmlAttribute(AttributeName = "DisplayName")]
        public string DisplayName { get; set; }
        [XmlAttribute(AttributeName = "StaticName")]
        public string StaticName { get; set; }
        [XmlAttribute(AttributeName = "Group")]
        public string Group { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "TermStore")]
        public string TermStore { get; set; }
        [XmlAttribute(AttributeName = "TermSet")]
        public string TermSet { get; set; }
        [XmlAttribute(AttributeName = "DefaultValue")]
        public string DefaultValue { get; set; }
        [XmlAttribute(AttributeName = "Required")]
        public string Required { get; set; }
        [XmlAttribute(AttributeName = "Description")]
        public string Description { get; set; }
    }
    [XmlRoot(ElementName = "ContentTypeSiteColumns")]
    public class ContentTypeSiteColumns
    {
        [XmlElement(ElementName = "Sitecolumn")]
        public List<Sitecolumn> Sitecolumn { get; set; }
    }
    [XmlRoot(ElementName = "ContentType")]
    public class ContentType
    {
        [XmlElement(ElementName = "ContentTypeSiteColumns")]
        public ContentTypeSiteColumns ContentTypeSiteColumns { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Parent")]
        public string Parent { get; set; }
        [XmlAttribute(AttributeName = "Group")]
        public string Group { get; set; }
        [XmlAttribute(AttributeName = "Description")]
        public string Description { get; set; }
    }
    [XmlRoot(ElementName = "ContentTypes")]
    public class ContentTypes
    {
        [XmlElement(ElementName = "ContentType")]
        public List<ContentType> ContentType { get; set; }
    }
