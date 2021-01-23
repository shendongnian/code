    public interface IConnectionConfig
    {
        string GetConnectionString();
    }
    
    public class LocalConnectionConfig : IConnectionConfig
    {
        public string GetConnectionString()
        {
            return "db connection for local";
        }
    }
    
    public class BBAConnection : IBBAConnection 
    { 
        private readonly IConnectionConfig config;
      
        public BBAConnection(IConnectionConfig config)
        {
            this.config = config;
        }
    
        public IDbConnection GetConnection()
        {
            string _connectionString = "";
            IDbConnection connection = null;
    
            try
            {
                connection = new System.Data.SqlClient.SqlConnection(this.config.GetConnectionString());
                
                connection.Open();
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
            }
    
            return connection;
        }
    }
