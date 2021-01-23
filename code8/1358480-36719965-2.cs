    private static IEnumerable<IDataRecord> SourceData(String sql) {
      using (SqlConnection con = new SqlConnection(ConnectionStringHere)) {
        con.Open();
    
        using (SqlCommand q = new SqlCommand(sql, con)) {
          using (var reader = q.ExecuteReader()) {
            while (reader.Read()) {
              //TODO: you may want to add additional conditions here
    
              yield return reader; 
            }
          }
        }
      }
    }
    
    private static IEnumerable<String> ToCsv(IEnumerable<IDataRecord> data) {
      foreach (IDataRecord record in data) {
        StringBuilder sb = new StringBuilder();
    
        for (int i = 0; i < record .FieldCount; ++i) {
          String chunk = Convert.ToString(record .GetValue(0));
    
          if (i > 0)
            sb.Append(','); 
    
          if (chunk.Contains(',') || chunk.Contains(';'))
            chunk = "\"" + chunk.Replace("\"", "\"\"") +  "\"";
    
          sb.Append(chunk);
        }
    
        yield return sb.ToString(); 
      } 
    }
