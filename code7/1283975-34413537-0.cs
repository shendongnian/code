    using(var connection = new SqlConnection("Server..."))
    {
        var sqlCommand = connection.CreateCommand();
        sqlCommand.CommandText = "insert into Records values (...)";
        connection.Open();
        sqlCommand.ExecuteNonQuery(); //returns the number of records inserted
    }
