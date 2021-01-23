    string dbConnectionString = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";
    IDbConnection dbConnection = new SqliteConnection(dbConnectionString);
    dbConnection.Open();
    IDbCommand dbCommand = dbConnection.CreateCommand();
    dbCommand.CommandText = //write what you want here in SQLite syntax.
