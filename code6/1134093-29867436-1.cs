    public interface ISqlConnectionFactory
    {
       SqlConnection GenerateConnection();
    }
    
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
       private readonly string _connectionString;
    
       public SqlConnectionFactory()
       {
          _connectionString = "your connection string here";
       }
    
       public SqlConnection GenerateConnection()
       {
           return new SqlConnection(_connectionString);
       }
    }
