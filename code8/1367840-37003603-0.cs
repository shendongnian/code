    public partial class Product
    {
        public Product()
        {
            this.ProductDetails = new List<ProductDetail>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            this.Property(t => t.Name)
                .IsFixedLength()
                .HasMaxLength(10);
            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
    public partial class ProductDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
    public class ProductDetailMap : EntityTypeConfiguration<ProductDetail>
    {
        public ProductDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            this.Property(t => t.Title)
                .IsFixedLength()
                .HasMaxLength(10);
            this.Property(t => t.Summary)
                .IsFixedLength()
                .HasMaxLength(10);
            // Table & Column Mappings
            this.ToTable("ProductDetail");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductDetails)
                .HasForeignKey(d => d.ProductId);
        }
    }
