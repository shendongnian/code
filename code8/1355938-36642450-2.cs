    // Wrap IDisposable into using
    using (SqlConnection sql_conn = new SqlConnection(ConnectionString)) {
      // Make SQL readable
      // Make SQL parametrized (and not formatted) when it's possible
      String sql = 
        @"select ItemType 
            from ItemTable 
           where ItemID = @prm_ItemId"; 
    
      // Wrap IDisposable into using
      using (SqlCommand sql_cmd = new SqlCommand(sql, sql_conn)) {
        // I don't know ItemID's type that's why I've put AddWithValue 
        sql_cmd.Parameters.AddWithValue("@prm_ItemId", item_id);
    
        // Wrap IDisposable into using
        using (SqlDataReader rdr = sql_cmd.ExecuteReader()) {
          // rdr.HasRows is redundant - rdr.Read() returns true if record has been read
          if (rdr.Read()) {
            String key = Convert.ToString(rdr.GetValue(0));
            // Put break point here: what is the "key" value?
            item_type = TypesMap[key];
          }
        }
      } 
    }
