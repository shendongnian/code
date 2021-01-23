    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Foo>().HasMany(f => f.Bars).WithMany(b => b.Foos)
                .Map(m => 
                    m.ToTable("FooBars")
                    // Optionally specify the key column names...
                    .MapLeftKey("FooId") 
                    .MapRightKey("BarId")
                );
        modelBuilder.Entity<Foo>().HasMany(f => f.SubBars).WithMany(sb => sb.Foos).Map(m => m.ToTable("FooSubBars"));
    }
