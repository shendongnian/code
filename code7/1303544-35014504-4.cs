    modelBuilder.Entity<User>() 
        .Property(c => c.Id) 
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); 
    
    modelBuilder.Entity<BackendUser>().Map(m => 
    { 
        m.MapInheritedProperties(); 
        m.ToTable("BackendUser"); 
    }); 
    
    modelBuilder.Entity<ResellerContact>().Map(m => 
    { 
        m.MapInheritedProperties(); 
        m.ToTable("ResellerContact"); 
    });
