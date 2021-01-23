    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {    
        modelBuilder.Entity<TestParameters>()
            .HasMany(x => x.StudentGroup)
            .WithMany(x => x.TestParameters)
        .Map(x =>
        {
            x.ToTable("StudentGroupTestParameter")
            x.MapLeftKey("Id");
            x.MapRightKey("Code");
        });
    }
