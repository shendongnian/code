    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }  
    
        public ICollection<Supplier> Suppliers { get; set; }
    }
    
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public ICollection<Product> Products { get; set; }
    }
