    public class MyContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> Lines { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                        .HasMany(a => a.Lines)
                        .WithRequired(b => b.Orders)
                        .WillCascadeOnDelete();
        }
    }
