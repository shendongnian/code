    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new ParentArcMapping());
        modelBuilder.Configurations.Add(new ArcMapping());
        modelBuilder.Configurations.Add(new NodeMapping());
    }
