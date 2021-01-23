    ...
    // Put IDisposable into using
    using (OleDbConnection con = new OleDbConnection(str)) {
      con.Open();
     
      // Make SQL being readable
      string query = 
        @"SELECT [Total price],
                 [Parameter change]  
            FROM [Firebird m0] 
           WHERE [Damage] = ?"; 
      
      // Put IDisposable into using
      using (OleDbCommand cmd = new OleDbCommand(query, con)) {
        cmd.Parameters.Add(comboBox6.Text);
    
        // Put IDisposable into using
        using (OleDbDataReader dbr = cmd.ExecuteReader()) {
          if (dbr.Read()) // You don't need "while" just "if"
            textBox15.Text = Convert.ToString(dbr["[Total price]"]);
        }
      }
    }
