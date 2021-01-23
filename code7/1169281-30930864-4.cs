    string ConnectionString = "data source=192.168.x.x;database=database;user id=user;password=pass";
    string Command = "SELECT TOP 1 Column FROM Table";
    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
    {
        myConnection.Open();
        using (SqlCommand myCommand = new SqlCommand(Command, myConnection))
        {
            decimal Result = (decimal)myCommand.ExecuteScalar();
        }
    }
