    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    modelBuilder.Entity<Orders>()
                .HasMany<Product>(s => s.Products)
                .WithMany(c => c.Orders)
                .Map(cs =>
                        {
                            cs.MapLeftKey("OrderId");
                            cs.MapRightKey("ProductId");
                            cs.ToTable("TABLENAMEFORRELATIONALTABLE");
                        });
    }
