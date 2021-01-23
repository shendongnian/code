        public class MembershipUser
        {
            public Guid MembershipUserId { get; set; }
        
            public IsSupplier { get; set; } //I like to have a discriminator field
    
            //if it is a supplier, there is a relationship with the supplier table
            //it it is not, the property will be null
            public Supplier Supplier { get; set; } 
        }
        public class Supplier
        {
             //pk 
             public Guid SupplierId { get; set; }             
             //navigation property
             public MembershipUser User { get; set; }
       
             //... other properties
        }
      mapping:
         modelBuilder.Entity<MembershipUser>()
             .HasKey(i => i.MembershipUserId);
    
         modelBuilder.Entity<MembershipUser>()
            .HasOptional(i => i.Supplier)
            .WithOptionalPrincipal(i => i.User)
            .Map(i => i.MapKey("MemberhsipUserId"))
            .WillCascadeOnDelete(false);
    
         modelBuilder.Entity<Supplier>()
            .HasKey(i => i.SupplierId);
