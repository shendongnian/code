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
