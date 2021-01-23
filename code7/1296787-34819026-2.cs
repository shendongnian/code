    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();
        modelBuilder.Entity<SuitabilityCheck>().HasKey(x => x.Id)
            .Map(x =>
            {
                x.Property(y => y.ShardKey).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_SuitabilityCheck_ShardKey_Id", 1) { IsUnique = true }));
                x.Property(y => y.Id).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_SuitabilityCheck_ShardKey_Id", 2)));
                // Mention all other columns of SuitabilityCheck, otherwise the class is split into multiple tables
            });
    }
