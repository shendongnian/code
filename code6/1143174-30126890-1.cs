    // Map the GarmentFonts table
    modelBuilder.Entity<Font>()
        .HasMany(m => m.Garments)
        .WithMany()
        .Map(m =>
        {
            m.MapLeftKey("FontId");
            m.MapRightKey("GarmentId");
            m.ToTable("GarmentFonts");
        });
