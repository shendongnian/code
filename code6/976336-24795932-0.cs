    using (var conn = new SqlConnection(connectionString))
    using (var command = new SqlCommand("addSystemError", conn) { 
                           CommandType = CommandType.StoredProcedure }) {
     conn.Open();
     
     /* Add the parameters in command
      .    
      . 
      .
     */
     command.ExecuteNonQuery();
     conn.Close();
    }
