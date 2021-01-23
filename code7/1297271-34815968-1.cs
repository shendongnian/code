    Regex request = new Regex(@"request class winmo.SyncML");
    String line;
    while ((line = sr.ReadLine()) != null)
    {
     if(req.Success)
     {
      Match req = request.Match(line);
      var xmlLine = line = sr.ReadLine();
      if (null == xmlLine) break;
      string s = xmlLine.Substring(line.IndexOf("<?xml "));
     }
    }
