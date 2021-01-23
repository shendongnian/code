    public class Product
    {
        [Key]
        public long ProductId { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
    
        [InverseProperty("Product")]
        public ICollection<ProductCategoryLink> CategoriesLinks { get; set; }
    }
    
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }        
        public string Name { get; set; }
    
        [InverseProperty("Category")]
        public ICollection<ProductCategoryLink> ProductsLinks { get; set; }
    }
    
    public class ProductCategoryLink
    {
        [Key]
        [Column(Order=0)]
        [ForeignKey("Product")]
        public long ProductId { get; set; }        
        public Product Product { get; set; }
        [Key]
        [Column(Order=1)]
        [ForeignKey("Category")]
        public long CategoryId { get; set; }       
        public Category Category { get; set; }
    }
