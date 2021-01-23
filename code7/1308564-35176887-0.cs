    [Serializable]
    public enum EAction
    {
        defaultAction,
    }
    [XmlRoot("Configuration")]
    public class Configuration
    {
        public Configuration()
        {
            Products = new List<Product>();
        }
        [XmlElement("Product", Type = typeof(Product))]
        public List<Product> Products { get; set; }
    }
    public class ConfigurationItem
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("action")]
        public EAction Action { get; set; }
    }
    public class ConfigurationItemCollection : ConfigurationItem, IEnumerable<ConfigurationItem>
    {
        [XmlIgnore]
        public IEnumerable<ConfigurationItem> Children
        {
            get
            {
                return _items;
            }
        }
        private List<ConfigurationItem> _items = new List<ConfigurationItem>();
        public virtual void Add(object item)
        {
            ConfigurationItem cfgItem = item as ConfigurationItem;
            if (cfgItem != null)
                _items.Add(cfgItem);
        }
        public IEnumerator<ConfigurationItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
    [XmlInclude(typeof(Category))]
    public class Product : ConfigurationItem
    {
        public Product()
        {
            Items = new List<ConfigurationItem>();
        }
        [XmlElement("Category", Type = typeof(Category))]
        [XmlElement("Addon", Type = typeof(Addon))]
        public List<ConfigurationItem> Items { get; set; }
    }
    [XmlInclude(typeof(Addon))]
    public class Category : ConfigurationItem
    {
        public Category()
        {
            Items = new List<ConfigurationItem>();
        }
        [XmlElement("Category", Type = typeof(Category))]
        [XmlElement("Addon", Type = typeof(Addon))]
        public List<ConfigurationItem> Items { get; set; }
    }
    public class Addon : ConfigurationItem
    {
    }
