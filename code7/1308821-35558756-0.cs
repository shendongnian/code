    namespace MyApp.DataAccessLayer
    {
        public class DynamicContext : DbContext
        {
            protected string connectionName = "DynamicConnection";
    
            protected string myServerName;
    
            protected string myUserId;
    
            protected string myPassword;
    
            /**
             * Created the connection to the server using the giving connection string name.
             * This constructor will allow you to connect to any connection string found in the Web.config file
             * 
             * @param connName
             */
            public DynamicContext(string serverName = null, string userID = null, string password = null)
                : base("DynamicConnection")
            {
                myServerName = serverName;
    
                myUserId = userID;
    
                myPassword = password;
            }
    
            /**
             * This constructor will allow you to construct a context by giving a string and it can only be call from the class itself
             * 
             */
            private DynamicContext(string connectionString)
                : base(connectionString)
            {
            } 
    
    
            /**
             * Changes the default database
             * 
             * @param databaseName
             */
            public DynamicContext setDatabase(string databaseName)
            {
                //Get the existing string for dynamic connection
                var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
    
                //convert the existsing string into an object
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
    
                //change the database before creating the new connection
                builder.InitialCatalog = databaseName;
    
                if (myServerName != null){
                    builder.DataSource = myServerName;
                }
    
                if (myUserId != null){
                    builder.UserID = myUserId;
                }
    
                if (myPassword != null){
                    builder.Password = myPassword;
                }
    
                return new DynamicContext(builder.ConnectionString);
            }
    
        }
    }
