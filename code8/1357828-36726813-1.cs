        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOptional(e => e.SalesPerson)
                .WithMany(e => e.Clients)
                .HasForeignKey(e => e.SalesPersonId);
        }
