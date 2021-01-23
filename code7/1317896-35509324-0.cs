    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
    
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        
        public int BillingAddressId { get; set; }
        public Address BillingAddress { get; set; }
        public int DeliveryAddressId { get; set; }
        public Address DeliveryAddress { get; set; }
    }
    
    public class MyDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
            modelBuilder.Entity<User>()
                .HasRequired(p => p.DeliveryAddress)
                .WithMany()
                .HasForeignKey(p => p.DeliveryAddressId)
                .WillCascadeOnDelete(false);
                
            modelBuilder.Entity<User>()
                .HasRequired(p => p.BillingAddress)
                .WithMany()
                .HasForeignKey(p => p.BillingAddressId)
                .WillCascadeOnDelete(false);
        }
    }
