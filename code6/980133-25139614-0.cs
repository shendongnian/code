    public partial class MyModel : ApplicationDbContext
        {
            public MyModel()
                : base("DefaultConnection")
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyModel>());
            }
            //....other properties
    
            public virtual DbSet<ProductClientDiscount> ProductClientPrice { get; set; }
            public virtual DbSet<ClientCategoryDiscount> ClientCategoryDiscount { get; set; }
            public virtual DbSet<Product> Products { get; set; }
            //....other properties
    
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
    
    
               modelBuilder.Entity<ClientCategoryDiscount>().Property(x => x.PercentDiscountRent).HasPrecision(12, 9);
                modelBuilder.Entity<ClientCategoryDiscount>().Property(x => x.PercentDiscountSale).HasPrecision(12, 9);
                modelBuilder.Entity<ProductClientDiscount>().Property(x => x.PercentDiscountRent).HasPrecision(12, 9);
                modelBuilder.Entity<ProductClientDiscount>().Property(x => x.PercentDiscountSale).HasPrecision(12, 9);
                modelBuilder.Entity<Product>().Property(x => x.SalePrice).HasPrecision(12, 9);
                modelBuilder.Entity<Product>().Property(x => x.RentPrice).HasPrecision(12, 9);
    
            }
        }
