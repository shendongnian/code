    void Main()
    {
    
    
    	Regex regex = new Regex(@"S\d{1,2}([-+]?E\d{1,2})+");
    	Match match = regex.Match("Defiance.S03E01E02E03.Custom.DKSubs.720p.HDTV.x264-NGSerier");
    	if (match.Success)
    	{
    	    Console.WriteLine(match.Value);
    	}
    	match = regex.Match("Defiance.S03E01-E03.Custom.DKSubs.720p.HDTV.x264-NGSerier");
    	if (match.Success)
    	{
    	    Console.WriteLine(match.Value);
    	}
    	match = regex.Match("Defiance.S03E01E02E03.Custom.DKSubs.720p.HDTV.x264-NGSerier");
    	if (match.Success)
    	{
    	    Console.WriteLine(match.Value);
    	}
    	
    }
    
    
