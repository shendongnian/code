    private static String ToCsv(String value) {
      if (String.IsNullOrEmpty(value))
        return "";
      StringBuilder sb = new StringBuilder(value.Length);
      foreach (var ch in value) {
        if ((ch == ',') || (ch == '\\') || (ch == '"'))
          sb.Append('\\'); 
        sb.Append(ch);
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
