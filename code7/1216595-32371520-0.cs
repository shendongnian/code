      //TODO: do not hardcode connection string here (esp. password), but load it
      String connectionString = @"Data Source=SHUBHAM-PC\SQLEXPRESS;Initial Catalog=DB1;Persist Security Info=True;User ID=sa;Password=***********";
    
      // wrap IDisposable into using
      using (SqlConnection conn = new SqlConnection(connectionString)) {
        conn.Open();
      
        // wrap IDisposable into using
        using (SqlCommand q = new SqlCommand(conn)) {
          // Make your sql being readable:
          q.CommandText =
            @"select max(useCountForMonth) as useCounter
                from tblHRRelax";
    
          // wrap IDisposable into using
          using (var reader = q.ExecuteReader()) {
            if (reader.Read()) // no "while" - just one value to read - "if" 
              MessageBox.Show("Reader Value " + Convert.ToString(reader[0])); // do you want Int32 or String?
          }
        }
      } 
