    modelBuilder.Entity<Image>() 
      .Property(c => c.ImageID) 
      .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); 
 
    modelBuilder.Entity<ThumbNail>().Map(m => 
    { 
        m.MapInheritedProperties(); 
        m.ToTable("Thumbnails");
    }); 
