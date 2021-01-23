        public class CustomerContext : DbContext
        {
            public CustomerContext()
                : base("DBConnectionString")
            {
                //If model change, It will re-create new database.
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomerContext>());
            }
        
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                //Set primary key to Customer table
                modelBuilder.Entity<Customer>().HasKey(m => m.CustomerId);
               
        
                //set primary key to Address table
                modelBuilder.Entity<CustomerAddress>().HasKey(m => m.DateFrom);
        
                modelBuilder.Entity<AddressType>().HasKey(m => m.AddressTypeId);
                modelBuilder.Entity<Address>().HasKey(m => m.AddressId);
        
                //Set foreign key property
                modelBuilder.Entity<CustomerAddress>().HasRequired(t => t.Customer)
                    .WithMany().HasForeignKey(t => t.CustomerId);
        
                modelBuilder.Entity<CustomerAddress>().HasRequired(t => t.AddressType)
                    .WithMany().HasForeignKey(t => t.AddressTypeId);
        
                modelBuilder.Entity<CustomerAddress>()
                    .HasRequired(t => t.Address)
                    .WithMany()
                    .HasForeignKey(t => t.AddressId);
            }
