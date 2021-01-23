    using (var connection = new MySqlConnection("connection string here"))
    using (var command = new MySqlCommand("SQL code here", connection))
    {
        command.Parameters.AddWithValue("@ParamName", paramValue);
    
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch
        {
            // ...
        }
    }
