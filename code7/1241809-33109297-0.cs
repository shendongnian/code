    public class Repository 
    {
        public Repository(String connectionStringName)
        {
            String connectionString = 
                ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
 
            // ...
        }
    }
