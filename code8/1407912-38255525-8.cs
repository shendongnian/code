    private SqlConnection TryEstabilishConnection(params int?[] portNumbers) {
        foreach (int? portNumber in portNumbers) {
            var connectionString = CreateConnectionStringBuilder();
            if (portNumber != null)
                connectionString.DataSource += $",{portNumber}";
        
            var connection = TryEstabilishConnection(connectionString.ToString());
            if (connection != null)
                return connection;
        }
        // Connection failed with all given ports...
        return null;
    }
    private SqlConnection TryEstabilishConnection(string connectionString) {
        for (int i=0; i < RetriesOnError; ++i) {
            try {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (SqlException) {
                if (i < RetriesOnError - 1)
                    Thread.Sleep(DelayBeforeRetry);
            }
        }
        return null;
    }
