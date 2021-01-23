    using (var conn = new SqlConnection("...Connection String..."))
    {
      conn.Open();
      using (var cmd = new SqlCommand())
      {
        cmd.Connection = conn;
    
        // Query1
        cmd.CommandText = "...Query1...";
        cmd.ExecuteNonQuery();
    
        // Query2
        cmd.CommandText = "...Query2...";
        cmd.ExecuteReader();
      }
    }
