    public class Hit
    {
        // Since "id" is expected in the XML, deserialize it explicitly.
        [XmlElement("id")]
        public string Id { get; set; }
        private readonly List<XElement> elements = new List<XElement>();
        [XmlAnyElement]
        public List<XElement> Elements { get { return elements; } }
        public string this[XName name]
        {
            get
            {
                return Elements.Where(e => e.Name == name).Select(e => e.Value).FirstOrDefault();
            }
            set
            {
                var element = Elements.Where(e => e.Name == name).FirstOrDefault();
                if (element == null)
                    Elements.Add(element = new XElement(name));
                element.Value = value;
            }
        }
        const string title = "Title";
        [XmlIgnore]
        public string Title
        {
            get
            {
                return this[title];
            }
            set
            {
                this[title] = value;
            }
        }
    }
