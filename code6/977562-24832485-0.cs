    public interface ISqlServerConnectionContextCache
    {
    	ISqlServerConnectionContext CurrentSqlServerConnectionContext { get; set; }
    }
    
    public class SqlServerConnectionContextScopeCache : ISqlServerConnectionContextCache
    {
    	ISqlServerConnectionContext CurrentSqlServerConnectionContext { get; set; }
    }
    
    public interface ISqlServerConnectionContextFactory
    {
      ISqlServerConnectionContext Create();
    }
    
    public class SqlServerConnectionContextFactory : ISqlServerConnectionContextFactory
    {
      private string _connectionString;
      private ISqlServerConnectionContextCache _connectionCache;
    
      public SqlServerConnectionContextFactory(ISqlServerConnectionContextCache connectionCache,
      	string connectionString)
      {
        _connectionCache = connectionCache;
        _connectionString = connectionString;  
      }
    
      public ISqlServerConnectionContext Create()
      {
        var connectionContext = new SqlServerConnectionContext(_connectionString);
        connectionContext.Open();
        _sqlServerConnectionContextProvider.CurrentSqlServerConnectionContext = connectionContext;
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
    
    public class MyTypeScopedByController
    {
    	public MyTypeScopedByController(ISqlServerConnectionContextCache connectionCache)
    	{
    		var sqlServerConnectionContext = connectionCache.CurrentSqlServerConnectionContext;
    	}
    }
    
    // AutoFac wiring
    builder.RegisterType<SqlServerConnectionContextScopeCache>()
    	.As<ISqlServerConnectionContextCache>()
    	.InstancePerLifeTimeScope();
    builder.RegisterType<SqlServerConnectionContextFactory>()
    	.As<ISqlServerConnectionContextFactory>()
    	.InstancePerDependency();
