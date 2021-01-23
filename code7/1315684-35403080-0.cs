        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
                    modelBuilder.Entity<Contact>()
            .HasMany(e => e.MyIntersections)
            .WithOptional(e => e.Contact)
            .HasForeignKey(e => e.ContactId);
                    modelBuilder.Entity<Account>()
            .HasMany(e => e.MyIntersections)
            .WithOptional(e => e.Account)
            .HasForeignKey(e => e.AccountId);
                    modelBuilder.Entity<Address>()
            .HasMany(e => e.MyIntersections)
            .WithRequired(e => e.Address)
            .HasForeignKey(e => e.AddressId)
            .WillCascadeOnDelete(false);
        }
