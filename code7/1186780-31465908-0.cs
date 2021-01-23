    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductAssociation> AssociatedProducts { get; set; }
        public virtual ICollection<ProductAssociation> ProductsAssociatedThisProduct { get; set; }
    }
    public class ProductAssociation
    {
        public int ProductId { get; set; }
        public int ProductAssociatedId { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Product Product { get; set; }
        public virtual Product ProductAssociated { get; set; }
    }
    public class Context : DbContext
    {
        public Context() : base("Model2")
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAssociation> ProductsAssociations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(i => i.ProductId);
            modelBuilder.Entity<ProductAssociation>()
                .HasKey(i => new {i.ProductId, i.ProductAssociatedId });
            modelBuilder.Entity<Product>()
                .HasMany(i => i.AssociatedProducts)
                .WithRequired(i => i.ProductAssociated)
                .HasForeignKey(i => i.ProductAssociatedId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Product>()
                .HasMany(i => i.ProductsAssociatedThisProduct)
                .WithRequired(i => i.Product)
                .HasForeignKey(i => i.ProductId)
                .WillCascadeOnDelete(false);
            
            base.OnModelCreating(modelBuilder);
        }
        
    }
