    using System.Data.SQLite;
    // ...
    var builder = new SQLiteConnectionStringBuilder
        {
            DataSource = @"C:\<Path to your data directory>\<New database file name>.db",
            Version = 3,
            // Any other connection configuration goes here
        };
    string connectionString = builder.ToString();
    
    using(SQLiteConnection databaseConnection = new SQLConnection(connectionString)) {
        // Open the connection to the new database
        databaseConnection.Open();
        // Import the SQL file database dump into the in-memory database
        SQLiteCommand command = databaseConnection.CreateCommand();
        string dumpFile = Path.Combine("Path to your sql dump file", "YourDumpFileName.sql");
        string importedSql = File.ReadAllText(dumpFile);
        command.CommandText = importedSql;
        command.ExecuteNonQuery();
    }
        
