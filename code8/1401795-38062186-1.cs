    public class CustomConnectionFactory : IDbConnectionFactory
    {
        public CustomConnectionFactory(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }
        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
