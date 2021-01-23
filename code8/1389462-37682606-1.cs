    public class MyDbContext : DbContext
    {
		public DbSet<Partner> Partners { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<BillingAddress> Addresses { get; set; }
        ...
    }
