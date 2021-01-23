    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("name=MyConnectionString")
        {
    
        }
    
        public DbSet<Tour> Tours { get; set; }
    }
