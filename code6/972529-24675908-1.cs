    List<string> list = new List<string>();
    using (StreamReader sr = new StreamReader(yourFilePath))
    {
      string line;
      while ((line = sr.ReadLine()) != null)
      {
        if (line.StartsWith("$False"))
           list.Add(line);
      }
    }
    // do something with your result list
