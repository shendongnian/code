    modelBuilder.Entity<Product>()
        .Map(m =>
        {
           m.Properties(p => new
           {
               p.Picture
           });
           m.ToTable("ProductPic");
        }
        .Map(m =>
        {
           m.Properties(p => new
           {
               p.Field1,
               p.Field2,
               ...
               p.Fieldn
           });
           m.ToTable("Product");
        }
