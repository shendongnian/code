    public class ConnellDbContext : IdentityDbContext<ConnellUser>
    {
        internal static string connection_string
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }
        public ConnellDbContext() : base(connection_string)
        {
    
        }
        // core tables
        public DbSet<Ballot> Ballots { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        //...
    }
