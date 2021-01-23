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
