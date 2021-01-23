      using (var stream = File.OpenRead("..."))
      {
        StringBuilder builder = null;
        StringBuilder xml = null;
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        {
          while (!reader.EndOfStream)
          {
            char c = (char)reader.Read();
            if (c == '<' && builder == null)
            {
              builder = new StringBuilder();
            }
            if (builder != null)
            {
              builder.Append(c);
            }
            if (xml != null)
            {
              xml.Append(c);
            }
            if (c == '>')
            {
              var token = builder.ToString();
              if (xml == null)
              {
                if (token.StartsWith("<element1", StringComparison.Ordinal) || token.StartsWith("<element2", StringComparison.Ordinal))
                {
                  xml = new StringBuilder("<?xml version='1.0' encoding='utf-8' ?>");
                  xml.Append(token);
                }
              }
              else
              {
                if (token.StartsWith("</element1", StringComparison.Ordinal) || token.StartsWith("</element2", StringComparison.Ordinal))
                {
                  XElement element = XElement.Parse(xml.ToString());
                  // do something with the element
                  xml = null;
                }
              }
              builder = null;
            }
          }
        }
      }
