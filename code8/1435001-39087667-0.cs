    public void addRow (string[] values) {
      // Validate public methods arguments 
      if (null == values)
        throw new ArgumentNullException("values"); 
     
      // Make the query parametrized: it's faster and not prone to SQL injection 
      // Do not append String in a loop; use Join instead
      string sql = string.Format("INSERT INTO {0} VALUES ({1})",
        tableName, 
        string.Join(", ", values.Select((item, index) => "@param_" + index.ToString()));
    
      // wrap IDisposable into using
      // let createConnection() return the connection created 
      using (var con = createConnection()) {
        con.Open();
    
        // wrap IDisposable into using
        using (var cmd = new SqlCommand(sql, con)) {
          // Parametrized query: parameters assigning
          for (int index = 0; index < values.Length; ++index)
            cmd.Parameters.AddWithValue("@param_" + index.ToString(), values[i]); 
    
          // Finally query executing
          cmd.ExecuteNonQuery();
        }
      }
    }
