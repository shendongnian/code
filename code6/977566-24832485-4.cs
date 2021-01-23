    public interface ISqlServerConnectionContextCache
    {
    	ISqlServerConnectionContext CurrentContext { get; set; }
    }
    
    public class SqlServerConnectionContextScopeCache : ISqlServerConnectionContextCache
    {
    	public ISqlServerConnectionContext CurrentContext { get; set; }
    }
    
    public interface ISqlServerConnectionContextFactory
    {
      ISqlServerConnectionContext Create();
    }
    
    // The factory has the cache as a dependancy
    // This will be the first use of the cache and hence
    // AutoFac will create a new one at the scope of the controller
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
        _sqlServerConnectionContextProvider.CurrentContext = connectionContext;
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
    
    // As the cache is lifetime scoped it will receive the single instance
    // of the cache associated with the current lifetime scope
    // Assuming we are within the scope of the controller this will receive
    // the cache that was initiated by the factory
    public class MyTypeScopedByController
    {
    	public MyTypeScopedByController(ISqlServerConnectionContextCache connectionCache)
    	{
    		var sqlServerConnectionContext = connectionCache.CurrentContext;
    	}
    }
    
    // AutoFac wiring
    builder.RegisterType<SqlServerConnectionContextScopeCache>()
    	.As<ISqlServerConnectionContextCache>()
    	.InstancePerApiRequest();
    builder.RegisterType<SqlServerConnectionContextFactory>()
    	.As<ISqlServerConnectionContextFactory>()
      	.InstancePerDependency();
