    class CommandFactory
    {
        public SqlCommand CreateCommand(SqlConnection connection)
        {
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["commandTimeout"])
            };
            return command;
        }
    }
