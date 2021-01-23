    public class ConnectionManager
    {
        private static IConfiguration currentConfig;
    
        public static void SetConfig(IConfiguration configuration)
        {
            currentConfig = configuration;
        }
    
        /// <summary>
        /// Get a connection to the database.
        /// </summary>
        public static SqlConnection GetConnection
        {
            get
            {
                string connectionString = currentConfig.GetConnectionString("MyConnection");
                // Create a new connection for each query.
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
        }
    }
