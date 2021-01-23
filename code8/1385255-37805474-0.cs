    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Model>()
            .Ignore(m => m.NotMappedProperty)
            .Property(typeof(string), "_roles");
    
        base.OnModelCreating(modelBuilder);
    }
