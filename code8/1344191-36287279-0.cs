    public abstract class ConnectionStringLoader : IConnectionStringLoader
    {
        private readonly string _connectionStringName;
    
        public ConnectionStringLoader(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }
    
        public string Get()
        {
            var cs = ConfigurationManager.ConnectionStrings[_connectionStringName];
            if (cs != null)
            {
                return cs.ConnectionString;
            }
            return null;
        }
    
        public void Write()
        {
            Console.WriteLine(_connectionStringName);
        }
    }
    
    public sealed class DbConnectionStringLoader : ConnectionStringLoader, IDbConnectionStringLoader
    {
        public DbConnectionStringLoader(string connectionStringName):base(connectionStringName)
        {
            
        }
        //Implement methods here just belongs to IDbConnectionStringLoader
    }
    
    public sealed class MetaDataConnectionStringLoader : ConnectionStringLoader, IMetaDataConnectionStringLoader
    {
        public MetaDataConnectionStringLoader(string connectionStringName):base(connectionStringName)
        {
            
        }
        //Implement methods here just belongs to IMetaDataConnectionStringLoader
    }
