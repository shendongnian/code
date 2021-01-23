    [Table("Products")]
    public class Product
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal InternalPrice { get; set; }
        public string Url { get; set; }
    }
    [Table("Categories")]
    public class Category
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Url { get; set; }
    }
    [Table("ProductCategories")]
    public class ProductCategory
    {
        [Key]
        [Column(Order = 0)]
        public string ProductId { get; set; }
        [Key]
        [Column(Order = 1)]
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
