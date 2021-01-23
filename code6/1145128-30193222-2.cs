    public class RookstayersDbContext : DbContext
    {
        public RookstayersDbContext() : base("RookstayersDbContext") { }
        public DbSet<Player> Players { get; set; }
    }
