    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
                .HasMany<Location>(s => s.Locations)
                .WithMany(c => c.Departments)
                .Map(cs =>
                        {
                            cs.MapLeftKey("DepartmentId");
                            cs.MapRightKey("LocationId");
                            cs.ToTable("DepartmentsLocations");
                        });
    }
