    public class DivAppsDataContext : DbContext
    {
        public DivAppsDataContext() : base("name=MyConnectionString")
        {
        }
    
        public DbSet<Account> Accounts{ get; set; }
    }
