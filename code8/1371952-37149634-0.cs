    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);
         // identity
         modelBuilder.Entity<Role>().Property(r => r.Id)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }
