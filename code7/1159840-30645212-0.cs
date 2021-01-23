    public class DartConnection : DbContext
    {
        public DartConnection()
        {
            // override the connection string
            this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["MyAppSettingDB"].ConnectionString;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
