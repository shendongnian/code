    using (var connection = new SQLiteConnection(ConnectionString))
    {
        using (var command = new SQLiteCommand())
        {
            string sql = "INSERT INTO MyTable (Field1) VALUES (@val1); SELECT last_insert_rowid();";
            command.Connection=connection;
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Parameters.Add("@val1", "MyValue");
           
            connection.Open();
            object obj = command.ExecuteScalar();
            long id = (long)obj; // Note regardless of data type, SQLite always returns it at long.
            // Do something with id
        }
    }
