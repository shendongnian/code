    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<ChronosItem >()
                    .HasKey(p => p.Id)
                    .Property(p => p.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
