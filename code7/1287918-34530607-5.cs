    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    { 
        modelBuilder.Configurations.Add(new PersonEntityTypeConfiguration());
        modelBuilder.Configurations.Add(new CarEntityTypeConfiguration());
    
        base.OnModelCreating(modelBuilder);
    }
