    String line;
    while ((line = sr.ReadLine()) != null)
    {
      if(line.Contains("<?xml "))
      {
          string s = line.Substring(line.IndexOf("<?xml "));
          // do something useful with s
      }
    }
