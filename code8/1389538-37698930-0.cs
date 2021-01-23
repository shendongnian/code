    protected override string ResolveConnectionString(out string connectionStringContext)
    {
        var connectionString = base.ResolveConnectionString(out connectionStringContext);
        if (string.IsNullOrEmpty(connectionString) || ReconnectOnError == false)
        {
            return connectionString;
        }
        var builder = new SqlConnectionStringBuilder(connectionString)
        {
            ConnectTimeout = 1; // Timeout value
        };
        return builder.ConnectionString;
    }
