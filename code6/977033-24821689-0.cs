    public class yourContext : IdentityDbContext<ApplicationUser>
    {
        static yourContext()
        {
            Database.SetInitializer<yourContext>(new MigrateDatabaseToLatestVersion<yourContext, Configuration>());
        }
        public yourContext()
            : base("Name=YourConnectionString")
        {
        }
    }
