    class CommandFactory
    {
        public static int CommandTimeout
        {
            get
            {
                int commandTimeout = 0;
                var configValue = ConfigurationManager.AppSettings["commandTimeout"];
                if(int.TryParse(configValue, out commandTimeout))
                   return commandTimeout;
                return 120; 
            }
        }
        public static SqlCommand CreateCommand(SqlConnection connection)
        {
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandTimeout = CommandTimeout
            };
            return command;
        }
    }
