    string test = "EXEC...";
	var lines = test.Split(new char [] { ',' }).ToList();
    lines = lines.Select((line, index) => 
    {
      var indexof = line.IndexOf("@schedule_uid");
      if (indexof > -1)
      {
        if (index == 0)
        {
          return line.Substring(0, indexof);
        }
        else
        {
          return null;
        }
      }
	  return line + ",";
    })
    .Where(line => line != null)
    .ToList();
    test = string.Join(string.Empty, lines);
