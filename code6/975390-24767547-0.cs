    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            this.SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlCeConnectionFactory("System.Data.SqlServerCe.4.0"));
    
            this.SetProviderServices("System.Data.SqlServerCe.4.0", SqlCeProviderServices.Instance);
    
            this.AddInterceptor(new NLogCommandInterceptor());// guardar logs
    
            this.SetMigrationSqlGenerator("System.Data.SqlServerCe.4.0", () => new SqlCeMigrationSqlGenerator());
        }
    }
    [DbConfigurationType(typeof(MyDbConfiguration))]
    public class TestContext : DbContext
