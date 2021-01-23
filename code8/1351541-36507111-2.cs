    public class DashboardContext : DbContext
    {
        public DashboardContext(IServiceProvider connectionString) : base (connectionString)
        {}
      public DbSet<NavBarEntity> NavBars { get; set; }
    }
