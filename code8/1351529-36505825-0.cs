    public class MyDbContext : DbContext
    {
       public DbSet<NavBarEntity> NavBars { get; set; }
       // Other entities
    }
