    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
            : base()
        {
            var strategy = System.Data.Entity.SqlServer.SqlAzureExecutionStrategy();
            SetExecutionStrategy("System.Data.EntityClient", strategy);
            SetExecutionStrategy("System.Data.SqlClient", strategy);
        }
    }
