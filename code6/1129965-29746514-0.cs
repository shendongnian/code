    public class Contact
    {
        public int Id { get; set; }    
        public User ContactUser{ get; set; }
    }
    
    public class User 
    {
        public int Id { get; set; }      
        public Contact Contact{ get; set; }
    }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>()
      .HasRequired(co => co.Contact)
      .WithOptional(cu => cu.ContactUser);
    }
