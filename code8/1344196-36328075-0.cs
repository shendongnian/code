    // If it is a loader the Write method makes no sense (IConnectionStringRepository?)
    public interface IConnectionStringLoader
    {
        string Get();
        void Write();
    }
    public class ConnectionStringLoader : IConnectionStringLoader
    {
        private readonly string _connectionStringName;
    
        public ConnectionStringLoader(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }
    
        public string Get()
        {
            var cs = ConfigurationManager.ConnectionStrings[_connectionStringName];
            if (cs != null)
            {
                return cs.ConnectionString;
            }
            return null;
        }
    
        public void Write()
        {
            Console.WriteLine(_connectionStringName);
        }
    }
