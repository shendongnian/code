    public class TestContext : DbContext
        {
            public TestContext()
                : base(GetConnection(),true)
            {
    
            }
    
            public static DbConnection GetConnection() { 
                var factory = DbProviderFactories.GetFactory("System.Data.SqlServerCe.4.0");
                var connection = factory.CreateConnection();
                connection.ConnectionString = "Data Source=C:/teste2.sdf;Persist Security Info=False;";
                return connection;
            }
