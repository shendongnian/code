    public class TestStoreAppContext : IStoreAppContext 
    {
        public TestStoreAppContext()
        {
            this.Products = new TestProductDbSet();
        }
        public DbSet<Product> Products { get; set; }
        public int SaveChanges()
        {
            return 0;
        }
        //....
