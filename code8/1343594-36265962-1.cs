    public static String RemoveQuots(String source) {
      if (String.IsNullOrEmpty(source))
        return source;
      StringBuilder sb = new StringBuilder(source.Length);
      Boolean inQuot = false;
      foreach (var ch in source) {
        if (ch == '"')
          inQuot = !inQuot;
        if (!inQuot || ((ch != '\n') && (ch != '\r')))
          sb.Append(ch);
      }
      return sb.ToString();
    }
    ...
    String source = "\"abc\ndef\"";
    String result = RemoveQuots(source);
