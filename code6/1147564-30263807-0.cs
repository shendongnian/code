    public class Product
    {
        [XmlArray]
        [XmlArrayItem("Id")]
        public List<int> Categories { get; set; }
    }
