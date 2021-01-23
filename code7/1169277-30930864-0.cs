    string Command = "SELECT TOP 1 value FROM Table";
    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
    {
        myConnection.Open();
        using (SqlCommand myCommand = new SqlCommand(Command, myConnection))
        {
            decimal Result = (decimal)myCommand.ExecuteScalar();
        }
    }
