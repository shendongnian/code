            //composite PKs of CroassRate entity
            modelBuilder.Entity<CrossRate>().HasKey(cr => new {cr.FromCurrencyId,   cr.ToCurrencyId});
          
            //one-to-many 
            modelBuilder.Entity<CrossRate>()
                        .HasRequired(s => s.FromCurrency)
                        .WithMany(s => s.FromCrossRates)
                        .HasForeignKey(s => new { s.FromCurrencyId });
            modelBuilder.Entity<CrossRate>()
                       .HasRequired(s => s.ToCurrency)
                       .WithMany(s => s.ToCrossRates)
                       .HasForeignKey(s => new { s.ToCurrencyId });
