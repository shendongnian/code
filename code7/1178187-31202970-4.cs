    public class Element
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string XPath { get; set; }
        [XmlElement(ElementName="TextBox", Type = typeof(TextBox))]
        [XmlElement(ElementName="Page", Type = typeof(Page))]
        [XmlElement(ElementName="Button", Type = typeof(Button))]
        [XmlElement(ElementName="Dialog", Type = typeof(Dialog))]
        public Element Parent { get; set; }
        [XmlArray("Children", IsNullable = false)]
        [XmlArrayItem(Type = typeof(TextBox))]
        [XmlArrayItem(Type = typeof(Page))]
        [XmlArrayItem(Type = typeof(Button))]
        [XmlArrayItem(Type = typeof(Dialog))]
        public Collection<Element> Children { get; set; }
    }
