    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasRequired(m => m.StateProvince)
                .WithMany() 
                .HasForeignKey(c => c.ShippingStateProvinceId)
                .WillCascadeOnDelete(false);
    
            modelBuilder.Entity<Customer>()
                .HasRequired(m => m.Country)
                .WithMany() 
                .HasForeignKey(c => c.ShippingCountryId)
                .WillCascadeOnDelete(false);
    
            modelBuilder.Entity<Customer>()
                .HasRequired(m => m.StateProvince)
                .WithMany() 
                .HasForeignKey(c => c.BillingStateProvinceId)
                .WillCascadeOnDelete(false);
    
            modelBuilder.Entity<Customer>()
                .HasRequired(m => m.Country)
                .WithMany() 
                .HasForeignKey(c => c.BillingCountryId)
                .WillCascadeOnDelete(false);
    
            modelBuilder.Entity<Vendor>()
                .HasRequired(m => m.StateProvince)
                .WithMany() 
                .HasForeignKey(c => c.StateProvinceId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Vendor>()
                .HasRequired(m => m.StateProvince)
                .WithMany() 
                .HasForeignKey(c => c.CountryId)
                .WillCascadeOnDelete(false);
    
   
            base.OnModelCreating(modelBuilder);
        }
