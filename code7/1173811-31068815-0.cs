    public class TestConfiguration
    {
        [XmlElement("Product")]
        public Product[] Products { get; set; }
    }
    
    public class Product
    {
        public string ProductCode { get; set; }
    
        [XmlArrayItem("Test")]
        public string[] Tests { get; set; }
    }
