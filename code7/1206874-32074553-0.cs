     using (SqlConnection connection = new SqlConnection(connectionString))
     {
         connection.Open();
         SqlCommand command = new SqlCommand(queryString, connection);
         // Setting command timeout to 60 second
         command.CommandTimeout = 60;
         try {
             command.ExecuteNonQuery();
         }
         catch (SqlException e) {
             Console.WriteLine("Got expected SqlException due to command timeout ");
             Console.WriteLine(e);
         }
    }
