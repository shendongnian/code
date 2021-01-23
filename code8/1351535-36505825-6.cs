    public class MyDbContext : DbContext
    {
       public MyDbContext(DbContextOptions<MyDbContext> options) 
          : base(options)
       { }
       public DbSet<NavBarEntity> NavBars { get; set; }
       // Other entities
    }
