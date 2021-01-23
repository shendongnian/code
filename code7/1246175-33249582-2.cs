    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("Server=(local), Database=MyDBName, User=blah-blah...")
        {
    
        }
    
        public DbSet<Tour> Tours { get; set; }
    }
