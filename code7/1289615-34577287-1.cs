    public class Context : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Order>()
                .HasRequired(x => x.Product)
                .WithMany(x => x.Orders);
            modelBuilder
                .Entity<Product>()
                .HasOptional(x => x.MostRecentOrder);
        }
    }
