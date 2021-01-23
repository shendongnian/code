    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntityA>()
            .HasOptional(x => x.EntityB)
            .WithOptionalDependent();
        modelBuilder.Entity<EntityB>()
            .HasOptional(x => x.EntityA)
            .WithOptionalDependent();
    }
