    public class ApplicationDbContext: DbContext
    {
    	public ApplicationDbContext() : base("connectionString")
    	{
    	}
    
    	public DbSet<Scores> Scores { get; set; }
    	public DbSet<GameLogs> GameLogs { get; set; }
    	public DbSet<IPs> IPs { get; set; }
        public DbSet<BannedIPs> BannedIPs { get; set; }
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    	    // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    	}
    }
