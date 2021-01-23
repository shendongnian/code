    public static string CompressSpacesOutsideQuotes(string input)
    {
      bool quoted = false;
      bool spaceSeen = false;
      var builder = new StringBuilder();
      foreach (char c in input)
      {
        if (c == '"')
        {
          quoted = !quoted;
        }
        if (c == ' ' && !quoted)
        {
          spaceSeen = true;
          continue;
        }
        if(spaceSeen)
        {
          builder.Append(' ');
          spaceSeen = false;
        }
        builder.Append(c);
      }
      if (spaceSeen) builder.Append(' ');
      return builder.ToString();
    }
