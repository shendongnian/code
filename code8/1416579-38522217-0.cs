    // You probably want to return value: decimal, not void
    public decimal Balance() {
      // Make sql readable
      string query = 
        @"SELECT balance 
            FROM history 
        ORDER BY id DESC 
           LIMIT 1 ";
      // do not cache connection, but create a new instead 
      using (MySqlConnection conn = new MySqlConnection(connectionStringHere)) {
        conn.Open();
        // wrap IDisposable into using  
        using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
          // you want to return values: ExecuteReader (or ExecuteScalar) 
          // instead of ExecuteNonQuery
          using (var reader = cmd.ExecuteReader()) {
            if (reader.Read())
              return Convert.ToDecimal(reader.GetValue(0));
            else
              return 0m; // cursor is empty, let's return 0   
          }
        }          
      }
    } 
