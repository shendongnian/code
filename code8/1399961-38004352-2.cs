    string connectionString = "...";
    using (var connection = new OleDbConnection(connectionString))
    {
        connection.Open();
        string query = "...";
        using (var command = new OleDbCommand(query, connection))
        {
            /* Initialize command.Parameters */
            command.ExecuteNonQuery();
        }
    }
