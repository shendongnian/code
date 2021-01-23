    public interface ISqlServerConnectionContextFactory
    {
      ISqlServerConnectionContext Create();
    }
    // Register this with your ContainerBuilder
    public class SqlServerConnectionContextFactory : ISqlServerConnectionContextFactory
    {
      private string _connectionString;
      public SqlServerConnectionContextFactory(string connectionString)
      {
        _connectionString = connectionString;  
      }
    
      public ISqlServerConnectionContext Create()
      {
        var connectionContext = new SqlServerConnectionContext(_connectionString);
        connectionContext.Open();
        return connectionContext;
      }
    }
    public class MyController : ApiController
    {
      private ISqlServerConnectionContext _sqlServerConnectionContext;
    
      public MyController(Func<string, ISqlServerConnectionContextFactory> connectionFactory)
      {
        _sqlServerConnectionContext = connectionFactory("MyConnectionString");
      }
    }
