    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        Configuration.LazyLoadingEnabled = false;
        modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
    }
