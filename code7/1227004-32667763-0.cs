    [Serializable]
    public class ProductRoot
    {
        [XmlArray]
        [XmlArrayItem(ElementName = "Product", Type = typeof(Product))]
        public List<Product> ProductList { get; set; }
    }
    [Serializable]
    public class Product
    {
        [XmlIgnore]
        private string _header;
        [XmlAttribute("Header")]
        public string Header {
            get { return this._header; }
            set { this._header = value; }
        }
        [XmlIgnore]
        private string _description;
        [XmlAttribute("Description")]
        public string Description {
            get { return this._description; }
            set { this._description = value; }
        }
        [XmlIgnore]
        private string _link;
        [XmlAttribute("Link")]
        public string Link {
            get { return this._link; }
            set { this._link = value; }
        }
        [XmlIgnore]
        private List<string> _properties;
        [XmlAttribute("Properties")]
        public List<string> Properties { get; set; }
    }
    static class Program
    {
        static void Main() {
            var productRoot = new ProductRoot();
            var products = new List<Product>();
            products.Add(new Product() { Description = "A", Properties = new List<string> { "PropA" } });
            products.Add(new Product() { Description = "B", Properties = new List<string> { "PropB" } });
            productRoot.ProductList = products;
            Test(productRoot);
        }
        static void Test<T>(T obj) {
            using (MemoryStream stream = new MemoryStream()) {
                XmlSerializer s = new XmlSerializer(typeof(T));
                using (var stringWriter = new StringWriter()) {
                    using (var writer = XmlWriter.Create(stringWriter)) {
                        s.Serialize(stringWriter, obj);
                    }
                    Console.WriteLine(stringWriter.ToString());
                }
            }
        }
    }
}
