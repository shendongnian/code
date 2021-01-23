    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        private string connectionString;
        public MyContext()
        {
            
        }
        public MyContext(DbContextOptions options, string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Used when instantiating db context outside IoC 
            if (connectionString != null)
            {
                var config = connectionString;
                optionsBuilder.UseSqlServer(config);
            }
         
            base.OnConfiguring(optionsBuilder);
        }
    }
