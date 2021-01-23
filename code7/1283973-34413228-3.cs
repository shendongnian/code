     using (SqlConnection connection = new SqlConnection("Server..."))
     {
         string command = "insert into Records values (...)";
         connection.Open();
         var command = new SqlCommand(command, connection);
         command.ExecuteNonQuery();
     }
