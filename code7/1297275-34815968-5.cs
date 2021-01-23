    Regex request = new Regex(@"^.+request class winmo.SyncML[^\<]+(\<\?xml [^`]+)");
    var lines = new List<String>(5);
	string line;
    while ((line = sr.ReadLine()) != null)
    {
	 //NOTE:You'll need to make sure this gets enough of your log file to get what you want
	 lines.Add(line);
	 while(lines.Count>4) 
	 	lines.RemoveAt(0);
		 
     Match req = request.Match(string.Join("\r\n", lines);
     if(req.Success)
      string s = req.Group[1].Value;
    }
