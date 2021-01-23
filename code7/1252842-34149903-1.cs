    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Property>().HasRequired(e => e.Address).WithOptional(e => e.Property);
    }
