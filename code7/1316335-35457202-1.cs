    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Add<UppercaseColumnNameConvention>();
        // ...
    }
