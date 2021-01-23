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
