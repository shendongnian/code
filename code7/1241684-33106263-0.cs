    public class ConnectionConfiguration : ConfigurationSection
    {
        private static ConnectionConfiguration connections = ConfigurationManager.GetSection("templates/connections") as ConnectionConfiguration;
        public static ConnectionConfiguration Connections
        {
            get
            {
                return connections;
            }
        }
     // the rest is the same
    }
