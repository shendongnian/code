    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString;
        
        public SqlConnectionFactory(string connectionString)
        {
             this.connectionString = connectionString;
        }
    
        public DbConnection GetNewConnection()
        {
             return new SqlConnection(this.connectionString);
        }
    }
