    public class Element
    {
        public Element() { }
        public string Name { get; set; }
        public string TagName { get; set; }
        public string XPath { get; set; }
        private readonly List<Element> children = new List<Element>();
        private Element parent = null;
        [XmlIgnore]
        public Element Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (parent == value)
                    return;
                if (parent != null)
                    parent.children.Remove(this);
                parent = value;
                if (parent != null)
                    parent.children.Add(this);
            }
        }
        [XmlIgnore]
        public ReadOnlyCollection<Element> Children
        {
            get
            {
                return children.AsReadOnly();
            }
        }
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
                if (value != null)
                    foreach (var child in value)
                        child.Parent = this;
            }
        }
    }
