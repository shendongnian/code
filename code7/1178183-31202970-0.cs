    public class Element
    {
    public string Name { get; set; }
    public string Id { get; set; }
    public string XPath { get; set; }
    public Element Parent { get; set; }
    [XmlArray("Children", IsNullable = false)]
    [XmlArrayItem(Type = typeof(TextBox))]
    [XmlArrayItem(Type = typeof(Page))]
    [XmlArrayItem(Type = typeof(Button))]
    [XmlArrayItem(Type = typeof(Dialog))]
    public Collection<Element> Children { get; set; }
    }
