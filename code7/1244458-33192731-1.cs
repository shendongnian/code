        public class Supplier
        {
            //The SupplierPK must be the MembershipUser Fk
            public Guid MembershipUserId { get; set; }             
    
            //navigation property, in case of the supplier is an user
            public MembershipUser User { get; set; }
    
            //... other properties
        }
      mapping:
        modelBuilder.Entity<MembershipUser>()
           .HasOptional(i => i.Supplier)
           .WithRequired(i => i.User)
           .WillCascadeOnDelete(false);
