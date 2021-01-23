    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
           base.OnModelCreating(modelBuilder);
           // identity
           modelBuilder.Entity<User>().Property(r=>r.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           modelBuilder.Entity<Role>().Property(r=>r.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }
