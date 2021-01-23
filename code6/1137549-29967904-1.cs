    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Testee>()
          .Property(e => e.Id)
          .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    }
