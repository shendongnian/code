      // wrap IDisposable into using
      using (OracleCommand cmd = new OracleCommand()) {  
        cmd.Connection = koneksidb.con;
    
        // Make SQL readable
        cmd.CommandText = 
          @"SELECT Notes 
              FROM Keterangan";
        
        // wrap IDisposable into using; do not close manually - dr.Close()
        using (OracleDataReader dr = cmd.ExecuteReader()) {
          // do not append string in loop - use SringBuilder
          StringBuilder sb = new StringBuilder(); 
    
          while (dr.Read()) {
            if (sb.Length > 0) // <- do not put delimiter before the very first item
              sb.Append(", "); // <- do you want a delimiter? Say, comma?
    
            // ".ToString()" provides debug info, use Convert.ToString() instead
            sb.Append(Convert.ToString(dr.GetValue(0))); 
          }  
    
          // Assign data once in order to prevent re-painting (and blinking)
          textBox1.Text = sb.ToString();
        } 
      } 
