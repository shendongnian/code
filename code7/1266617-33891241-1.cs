    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Customer>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
      ..
    }
