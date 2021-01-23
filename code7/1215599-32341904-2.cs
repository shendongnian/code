    using (SqlConnection connection = new SqlConnection(connectionString)) 
    {
        connection.Open();
        SqlCommand command = new SqlCommand(queryString, connection);
        // Setting command timeout to 60 seconds
        command.CommandTimeout = 60;
        try {
             command.ExecuteNonQuery();
        }
        catch (SqlException e) {
             // do something with the exception
        }
    }
