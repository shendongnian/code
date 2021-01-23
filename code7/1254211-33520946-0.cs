    public static IBus CreateMessageBus()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["easynetq"];
        if (connectionString == null || connectionString.ConnectionString == string.Empty)
        {
            throw new VaultServiceException("easynetq connection string is missing or empty");
        }
        return RabbitHutch.CreateBus(connectionString.ConnectionString);
    }
