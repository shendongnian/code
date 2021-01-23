    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Category:Product
    {
        public int Price { get; set; }
    }
