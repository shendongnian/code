    public class Item
    {
        [XmlIgnore]
        public Dictionary<string, string> Attributes { get; set; }
        [XmlAnyAttribute]
        public XmlAttribute[] XmlAttributes
        {
            get
            {
                if (Attributes == null)
                    return null;
                var doc = new XmlDocument();
                return Attributes.Select(p => { var a = doc.CreateAttribute(p.Key); a.Value = p.Value; return a; }).ToArray();
            }
            set
            {
                if (value == null)
                    Attributes = null;
                else
                    Attributes = value.ToDictionary(a => a.Name, a => a.Value);
            }
        }
    }
    public class RootNode
    {
        [XmlElement("Item")]
        public List<Item> Items { get; set; }
    }
