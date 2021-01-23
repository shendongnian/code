    public class CustomerOrder
    {
        public int Id {get; set;}
        public List<Product> Products {get; set;}
        public int CustomerId {get; set;}
    }
    
    public class Product
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public double Price {get; set;}
    }
