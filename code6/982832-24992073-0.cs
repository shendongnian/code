    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MapCompany>()
            .HasOptional(a => a.MapLocations)
            .WithOptionalDependent()
            .WillCascadeOnDelete(true);
    }
