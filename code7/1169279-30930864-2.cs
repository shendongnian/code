    string ConnectionString = "data source=192.168.x.x;database=database;user id=user;password=pass";   
    decimal Result = default(decimal);
    string Command = "SELECT TOP 1 value FROM Table";
    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
    {
        myConnection.Open();
        using (SqlCommand myCommand = new SqlCommand(Command, myConnection))
        {
            Result = (decimal)myCommand.ExecuteScalar();
        }
    }
    if(Result != default(decimal) && Result < 1)
    {
           //email
    }
