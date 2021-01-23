    public class MyDbContext : System.Data.Entity.DbContext
    {
        static MyDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());
        }
        // your other code
        public MyDbContext()
        : base("MyDb")
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }
        // ..
    }
