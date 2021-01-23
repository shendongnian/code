    using(var dbDataReader = dbCommand.ExecuteReader())
    {
        while(dbDataReader.Read())
        {
            // Do stuff with dbDataReader
        }
    }
