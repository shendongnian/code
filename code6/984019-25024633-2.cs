    protected override void OnModelCreating(DbModelBuilder modelBuilder) 
    { 
      base.OnModelCreating(modelBuilder);
      modelBuilder.ComplexType<Price>();
      modelBuilder.Entity<Product>()
        .Property(p => p.Price.Amount)
        .HasColumnName("Amount");
      modelBuilder.Entity<Product>()
        .Property(p => p.Price.Currency)
        .HasColumnName("Currency");
    }
