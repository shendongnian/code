       protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProductDescriptions >()
            .HasKey(c => new {c.ProductId , c.CompanyName , c.Language });
         modelBuilder.Entity<Product >()
            .HasKey(c => new {c.Id , c.CompanyName });
        modelBuilder.Entity<Product>()
            .HasRequired(p => p.ProductDescriptions )
            .WithMany(c => c.Product)
            .HasForeignKey(p => new {c.CompanyName , c.Id  });
      }
