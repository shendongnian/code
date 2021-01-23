    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       // Product to Links one-to-many 
       modelBuilder.Entity<ProductCategoryLink>()
                        .HasRequired<Product>(pcl => pcl.Product)
                        .WithMany(s => s.CategoriesLinks)
                        .HasForeignKey(s => s.ProductId);
       // Categories to Links one-to-many 
       modelBuilder.Entity<ProductCategoryLink>()
                        .HasRequired<Category>(pcl => pcl.Category)
                        .WithMany(s => s.ProductsLinks)
                        .HasForeignKey(s => s.CategoryId);
    }
