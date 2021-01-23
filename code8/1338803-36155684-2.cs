    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(p => p.ProductId);
            Property(p => p.ProductName)
               .IsRequired()
               .HasMaxLength(200);
            ...
        }
            
    }
