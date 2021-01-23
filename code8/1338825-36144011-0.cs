    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    modelBuilder.Entity<Package>()
                .HasMany<Product>(s => s.Products)
                .WithMany(c => c.Packages)
                .Map(cs =>
                        {
                            cs.MapLeftKey("PackageRefId");
                            cs.MapRightKey("ProductRefId");
                            cs.ToTable("PackageProduct");
                        });
    }
