    ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["test"];
    SQLiteConnection.CreateFile("MyDatabase.sqlite");
    var dbFact = DbProviderFactories.GetFactory(connectionString.ProviderName);
    
    using (var conn = dbFact.CreateConnection())
    {
        conn.ConnectionString = connectionString.ConnectionString;
        conn.Open(); // Exception gets thrown here
    }
