    // example string
    String input = "This page was last updated on Wed, Sep 2, 2015 at 6:40 PM";
    
    Regex regex = new Regex(@"[a-z]{3},\s[a-z]{3}\s[0-9],\s[0-9]{4}\sat\s[0-1]?[0-9]:[0-5][0-9]\s(AM|PM)", RegexOptions.IgnoreCase);
    
    Match match = regex.Match(input);
    
    if (match.Success)
    {
    	Group g = match.Groups[0];
    
    	CaptureCollection cc = g.Captures;
    	for (int j = 0; j < cc.Count; j++) 
    	{
    		Capture c = cc[j];
    		Console.WriteLine(c.Value);
    		
    		DateTime date;
    		Boolean isValidDate = DateTime.TryParseExact(c.Value, "ddd, MMM d, yyyy 'at' h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
    		
    		if(isValidDate)
    		{
    			Console.WriteLine(date);
    		}
    	}
    }
