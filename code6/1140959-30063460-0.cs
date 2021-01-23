    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
    
    public class Size {
        public int Id { get; set; }
        public string Name { get; set; }
  
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
    
    public class ProductSize {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public string Amount { get; set; }
    
        public virtual Size Size { get; set; }
        public virtual Product Product { get; set; }
    }
