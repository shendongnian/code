      using (SqlConnection connection = new SqlConnection(connectionString)) {
         connection.Open();
         SqlCommand command = new SqlCommand(queryString, connection);
         // Setting command timeout in seconds:
         command.CommandTimeout = 3600;
         try {
            command.ExecuteNonQuery();
         }
         catch (SqlException e) {
            Console.WriteLine(e);
         }
      }
