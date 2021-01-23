    string Command = "SELECT [UserName] FROM [aspnet_Users];";
    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
    {
        myConnection.Open();
        using (SqlCommand myCommand = new SqlCommand(Command, myConnection))
        {
            string Result = (string)myCommand.ExecuteScalar(); // returns one field
        }
    }
