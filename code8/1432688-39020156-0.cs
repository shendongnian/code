    public static string GetConnectionString() //Accessable form everywhere
    {
           var providerName = "Npgsql";
           var databaseName = decryptedName;
           var userName = decryptedUserName;
           var password = decryptedPassword;
           var host = decryptedHostName;
           var port = 5432;
           // Initializing the connection string builder for the provider
           SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
           sqlBuilder.ConnectionString = String.Format("Host={0};user id={1},password={2},database={3}",
           host, userName, password, databaseName);
           // Initialize the EntityConnectionStringBuilder.
           EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
           entityBuilder.Provider = providerName;
           entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
           return entityBuilder.ToString();
    }
