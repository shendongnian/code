    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            HasMany(p => p.Images).WithRequired(i => i.Product).HasForeignKey(i => i.ProductId);
        }
    }
