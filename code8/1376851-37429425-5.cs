    class OracleDBConfiguration : DbConfiguration
    {
      public OracleDBConfiguration()
      {
        this.SetDefaultConnectionFactory ( new System.Data.Entity.Infrastructure.LocalDbConnectionFactory("v12.0") ) ;
        this.SetProviderServices ( "Oracle.ManagedDataAccess.Client", Oracle.ManagedDataAccess.EntityFramework.EFOracleProviderServices.Instance ) ;
        this.SetProviderFactory  ( "Oracle.ManagedDataAccess.Client", Oracle.ManagedDataAccess.Client.OracleClientFactory.Instance ) ;
      }
    }
