    private static void ImportSomeData(string sql, DbConnection connection, int batchSize)
    {
        using(var command = connection.CreateCommand())
        {
            command.CommandText = sql;
            //Throw an exception here if needed
            var results = command.ExecuteReader();
            if (results.HasRows)
            {
              //...read here. 
            }
        }
    }
