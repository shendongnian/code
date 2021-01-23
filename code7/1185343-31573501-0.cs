    public class Element
    {
        public Element() { Children = new Collection<Element>(); }
        public string Name { get; set; }
        public string TagName { get; set; }
        public string XPath { get; set; }
        [XmlIgnore]
        public Element Parent { get; set; }
        [XmlIgnore]
        public Collection<Element> Children { get; set; }
        [XmlArray("Children", IsNullable = false)]
        [XmlArrayItem(Type = typeof(TextBox))]
        [XmlArrayItem(Type = typeof(Page))]
        [XmlArrayItem(Type = typeof(Button))]
        [XmlArrayItem(Type = typeof(Dialog))]
        [XmlArrayItem(Type = typeof(Site))]
        public Element[] ChildArrayCopy
        {
            get
            {
                return Children.ToArray();
            }
            set
            {
                Children.Clear();
                if (value != null)
                    foreach (var child in value)
                        child.SetParent(this);
            }
        }
    }
    public static class ElementExtensions
    {
        public static void SetParent(this Element child, Element parent)
        {
            if (child == null)
                throw new ArgumentNullException();
            if (child.Parent == parent)
                return; // Nothing to do.
            if (child.Parent != null)
                child.Parent.Children.Remove(child);
            child.Parent = parent;
            if (parent != null)
                parent.Children.Add(child);
        }
    }
