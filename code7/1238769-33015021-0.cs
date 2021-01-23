    using (var conn = new SqlConnection(connectionString))
    using (var command = new SqlCommand("[Treasury].[STP_T00042005]", conn)) 
    { 
      CommandType = CommandType.StoredProcedure })
      {
       conn.Open();
       command.ExecuteNonQuery();
       conn.Close();
      }
