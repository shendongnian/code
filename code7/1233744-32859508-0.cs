    modelBuilder.Entity<DerivedEntityObject1>().HasKey(t => t.Id);
    modelBuilder.Entity<DerivedEntityObject1>().Property(t => t.Id).
        HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
    modelBuilder.Entity<DerivedEntityObject2>().HasKey(t => t.Id);
    modelBuilder.Entity<DerivedEntityObject2>().Property(t => t.Id).
        HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
