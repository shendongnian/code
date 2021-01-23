    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //Configure Column
        modelBuilder.Entity<Employee>()
                    .Property(p => p.Id)
                    .HasColumnName("ID");
        modelBuilder.Entity<Employee>()
                    .Property(p => p.Name)
                    .HasColumnName("NAME");
    }
