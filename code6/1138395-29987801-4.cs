    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>()
                .HasMany(p => p.Dependencies)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("Package_ID");
                    m.MapRightKey("ID");
                    m.ToTable("PackageDependency");
                });
    }
