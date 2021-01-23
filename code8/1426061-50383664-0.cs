        public class ConnellDbContext : IdentityDbContext<ConnellUser>
        {
            public ConnellDbContext() : base(connection_string)
            {
        
            }
            // core tables
            public DbSet<Ballot> Ballots { get; set; }
            public DbSet<Campaign> Campaigns { get; set; }
            //...
        }
