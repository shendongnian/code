    var before = "var s1 = new SWFObject";
    var after = "</script>";
    var о = @"var s1 = new SWFObject(d
    aw
    da
    wd
    awd
    aw
    d
    aw
    d
    awd
            </script> ";
    Regex Rx = new Regex(before + "(.*)" + after,RegexOptions.Singleline);
    
    if (о is string)
    {
    	string s = о as string;
    	List<string> results = new List<string>();
    	foreach (Match match in Rx.Matches(s))
    	{
    		results.Add(match.Groups[1].Value);
    	}
    	  results.ToArray().Dump();
    }
