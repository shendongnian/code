    dbConnectionString = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";
    dbConnection = new SqliteConnection(dbConnectionString);
    dbConnection.Open();
    IDbCommand dbCommand = dbConnection.CreateCommand();
    dbCommand.CommandText = //do what you want here.
