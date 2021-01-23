    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    
        public virtual ICollection<Category> Categories { get; set; }
    }
            
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
