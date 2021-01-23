    public class MyDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.ComplexType<Picture>();
            modelBuilder.Configurations.Add(new PictureConfig());
        }
    }
