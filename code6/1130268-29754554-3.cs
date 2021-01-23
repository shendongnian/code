    public class Item
    {
        public Item()
        {
            this.Locations = new List<string>();
        }
        [XmlIgnore]
        public List<string> Locations { get; set; }
        [XmlIgnore]
        public string Location { get; set; }
        [XmlAnyElement]
        public XElement [] LocationElements {
            get
            {
                var elements = Locations.Select(l => new XElement(XName.Get("location", l), (l == Location).ToString())).ToArray();
                return elements;
            }
            set
            {
                Locations = value.Select(el => el.Name.Namespace.NamespaceName).ToList();
                Location = value.Where(el => bool.Parse(el.Value)).Select(el => el.Name.Namespace.NamespaceName).Distinct().SingleOrDefault() ?? string.Empty;
            }
        }
    }
