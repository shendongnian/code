    modelBuilder.Entity<VehicleInfo>()
        .Map<CarInfo>(c =>
        {
            c.MapInheritedProperties().ToTable("Car");
            c.Property(x => x.ID).HasColumnName("CarId");
            c.Property(x => x.Model);
        })
        .Map<BikeInfo>(c =>
        {
            c.MapInheritedProperties().ToTable("Bike");
            c.Property(x => x.ID).HasColumnName("BikeId");
            c.Property(x => x.IsEbike);
        });
