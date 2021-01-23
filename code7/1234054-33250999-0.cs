      protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>()
                .HasRequired(x => x.TechnicalCharacteristic)
                .WithMany(y => y.Options)
                .WillCascadeOnDelete(false);
                
            base.OnModelCreating(modelBuilder);
        }
