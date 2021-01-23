    public static class ConnectionString
    {
        public static string Get
        {
            get
            {
                if(ConfigurationManager.ConnectionStrings.Count == 0)
                    throw new Exception("No connection strings");
                var machineConnectionString = ConfigurationManager.ConnectionStrings["ConStringPrefix" + Environment.MachineName];
                var genericConnectionString = ConfigurationManager.ConnectionStrings["DefaultConString"];
                return  machineConnectionString ?? genericConnectionString;
            }
        }
    }
