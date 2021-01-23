    private static String ToCsv(String value) {
      if (String.IsNullOrEmpty(value))
        return "";
      StringBuilder sb = new StringBuilder(value.Length);
      bool hasSpecial = false; 
      foreach (var ch in value) {
        if ((ch == ',') || (ch == '\\') || (ch == '"')) {
          hasSpecial = true;
          sb.Append('\\'); 
        }
        sb.Append(ch);
      }
      if (hasSpecial) {
        sb.Insert(0, '"');
        sb.Append('"');
      } 
      return sb.ToString();
    }
    private static IEnumerable<String> TableToCsv(SqlConnection connection, 
                                                  string tableName, 
                                                  bool colummNames = true) {
      //TODO: simplest, but prone to SQL injection solution; tableName should be validated 
      String sql = String.Format("select * from {0}", tableName);
      using (var command = new SqlCommand(sql, connection))
        using (var reader = command.ExecuteReader()) {
          // Let's take columns' names from query
          if (colummNames)
            yield return String.Join(",", Enumerable
              .Range(0, reader.FieldCount)
              .Select(i => ToCsv(reader.GetName(i))));
          while (reader.Read())
            yield return String.Join(",", Enumerable
              .Range(0, reader.FieldCount)
              .Select(i => ToCsv(reader.GetFieldValue<String>(i))));
      }
    }
