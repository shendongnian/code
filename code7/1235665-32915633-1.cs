    using (var streamReader = new StreamReader(new MemoryStream(response), Encoding.GetEncoding("ISO-8859-1")))
    {
      while (streamReader.Peek() >= 0)
      {
        var csvLine = streamReader.ReadLine();
      }
    }
