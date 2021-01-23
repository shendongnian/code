    public class MyDbContext : DbContext
    {
        public MyDbContext() : base()
        {
            var cs = ConfigurationManager.ConnectionStrings["defaultConnection"]
                                         .ConnectionString;
            this.Database.Connection.ConnectionString = cs;                
        }
    }
