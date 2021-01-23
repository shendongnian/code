    [XmlRoot("item" /*, Namespace = "" */)] // Applies when an Item is the document root.
    [XmlType("item" /*, Namespace = "" */)] // Applies when an Item is not the document root.
    public class Item
    {
        [XmlIgnore]
        public string Location { get; set; }
        [XmlIgnore]
        public string LocationNamespace { get; set; }
        [XmlAnyElement]
        public XElement LocationElement
        {
            get
            {
                var ns = (XNamespace)LocationNamespace;
                var element = new XElement(ns + "location", Location);
                return element;
            }
            set
            {
                if (value == null)
                {
                    LocationNamespace = Location = null;
                }
                else
                {
                    LocationNamespace = value.Name.Namespace.NamespaceName;
                    Location = value.Value;
                }
            }
        }
    }
