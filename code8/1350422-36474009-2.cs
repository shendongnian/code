    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        public virtual List<ProductUsed> ProductsUsed { get; set; }
        public virtual List<ProductUsed> PreProducts { get; set; }
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
        public virtual Product PreProduct { get; set; }
        [Display(Name = "Product")]
        [Required]
        public int ParentProductID { get; set; }
        public virtual Product ParentProduct { get; set; }
        public int Quantity { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductUsed>()
                .HasRequired(p => p.ParentProduct)
                .WithMany(p => p.ProductsUsed)
                .HasForeignKey(p => p.ParentProductID);
            modelBuilder.Entity<ProductUsed>()
                .HasRequired(p => p.PreProduct)
                .WithMany(p => p.PreProducts)
                .HasForeignKey(p => p.PreProductID)
                .WillCascadeOnDelete(false);
        }
