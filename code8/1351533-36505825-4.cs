    public class MyDbContext : DbContext
    {
       public MyDbContext(string connectionString) 
          : base(connectionString)
       { }
       public DbSet<NavBarEntity> NavBars { get; set; }
       // Other entities
    }
