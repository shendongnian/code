    using (var myConnection = new SqlConnection(connectionString)) // using automatically disposes of object
    {
        myConnection.Open();
        string commandText = "insert into test (id, name) values ('dq1we3','d2qwe3')";
        using (var myCommand = new SqlCommand(commandText, myConnection))
        {
            myCommand.CommandType = CommandType.Text;
            myCommand.ExecuteNonQuery();
        }
    }
