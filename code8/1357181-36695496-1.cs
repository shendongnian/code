    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.ComplexType<Localization>();
        modelBuilder.Entity<Account>().Property(x => x.Localization.EnglishLabel).HasColumnName("en");
        modelBuilder.Entity<Account>().Property(x => x.Localization.FrenchLabel).HasColumnName("fr");
        // et cetera
    }
