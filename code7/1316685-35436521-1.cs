    public static IEnumerable<String> ToCsv(IDataReader reader, 
      Boolean includeHeaderAsFirstRow, 
      Char separator = ',',  
      Char quotation = '"') {
      if (null == reader)
        throw new ArgumentNullException("reader");
      StringBuilder Sb = new StringBuilder();
      if (includeHeaderAsFirstRow) {
        for (int i = 0; i < reader.FieldCount; ++i) {
          if (i > 0)
            Sb.Append(separator);
          String name = reader.GetName(i);
          if (name.Contains(separator) || name.Contains(quotation))
            name = name.Replace(quotation.ToString(), 
                                quotation.ToString() + quotation.ToString());
          Sb.Append(name);
        }
        yield return Sb.ToString();
      }
      while (reader.Read()) {
        Sb.Clear();
        for (int i = 0; i < reader.FieldCount; ++i) {
          if (i > 0)
            Sb.Append(separator);
          if (!reader.IsDBNull(i)) {
            String name = Convert.ToString(reader[i]);
            if (name.Contains(separator) || name.Contains(quotation))
              name = name.Replace(quotation.ToString(), 
                                  quotation.ToString() + quotation.ToString());
            Sb.Append(name);
          }
        }
        yield return Sb.ToString();
      }
    }
    public static void CsvToFile(String fileName, 
      IDataReader reader, 
      Char separator = ',',  
      Char quotation = '"') {
      if (String.IsNullOrEmpty(Path.GetExtension(fileName)))
        fileName += ".txt"; // ".csv" looks better here
      File.WriteAllLines(fileName, ToCsv(reader, separator, quotation));
    }
