    using (var conn = new MySqlConnection(connString))
    {
       conn.Open();
       var command = conn.CreateCommand();
       command.CommandText = strSQL; <--  just insert part like "START ... INSERT ... COMMIT;"
       command.ExecuteNonQuery();
       string result = command.LastInsertedId;
       return result;
    }
