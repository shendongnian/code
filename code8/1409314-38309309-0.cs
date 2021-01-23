    private static String trimNewLines(String value) {
      if (null == value)
        return value;
      StringBuilder sb = new StringBuilder(value.Length);
      Boolean inQuotation = false;
      foreach (char ch in value) {
        if (ch == '"')
          inQuotation = !inQuotation;
        if (inQuotation || ch != '\r' || ch != '\n')
          sb.Append(ch);
      }
      return sb.ToString();
    }
    ...
 
    String result = trimNewLines(File.ReadAllText(@"c:\MyData.csv"));
 
