    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            //one-to-many 
            modelBuilder.Entity<CrossRate>()
                        .HasRequired<Currency>(s => s.FromCurrency)
                        .WithMany(s => s.CrossRates)
                        .HasForeignKey(s => s.FromCurrencyId );
            modelBuilder.Entity<CrossRate>()
                        .HasRequired<Currency>(s => s.ToCurrency)
                        .WithMany(s => s.CrossRates)
                        .HasForeignKey(s => s.ToCurrencyId );
    }
        
