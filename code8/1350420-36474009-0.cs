    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        // Delete foreign key attribute
        public virtual List<ProductUsed> ProductsUsed { get; set; }
    }
    
    public class ProductUsed
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductUsedID { get; set; }
        [Display(Name = "Pre Product")]
        [Required]
        public int PreProductID { get; set; }
        [Display(Name = "Pre Product")]
        [ForeignKey("PreProductID")]
        public virtual Product PreProduct { get; set; }
        [Display(Name = "Product")]
        [Required]
        public int ParentProductID { get; set; }
        [ForeignKey("ParentProductID")]
        public virtual Product ParentProduct { get; set; }
        public int Quantity { get; set; }
    }
