    public class MyConfiguration : DbConfiguration 
    { 
        public MyConfiguration() 
        { 
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy()); 
        } 
    }
