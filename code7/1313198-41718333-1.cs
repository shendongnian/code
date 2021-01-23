    [DbConfigurationType(typeof(DataContextConfiguration))]
        public partial class MyEntity : DbContext
        {
            public static MyEntity CreateContext()
            {
                var context = new MyEntity();
                ((IObjectContextAdapter)context).ObjectContext.CommandTimeout = 180;
    
                return context;
            }
         }
    
    
    public class DataContextConfiguration : DbConfiguration
    {
        public DataContextConfiguration()
        {
    	SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy(5, new TimeSpan(0, 0, 10)));
        }
    } 
