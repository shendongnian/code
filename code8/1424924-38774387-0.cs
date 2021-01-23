    void Main()
    {
    	string search = @"(?<=initTest)(.|\n)*?(?=endTest)";
    	string text = GetData();
    	
    	MatchCollection matches = Regex.Matches(text, search, RegexOptions.Singleline | RegexOptions.IgnoreCase);
    
    	Console.WriteLine("there were {0} matches for '{1}'", matches.Count, search);
    	
    	for(int i=0; i < matches.Count; i++)
    		Console.WriteLine(matches[i].Groups[0].ToString());
    
    	Console.ReadLine();
    }
    
    public string GetData()
    {
    	StringBuilder sb = new StringBuilder();
    	sb.AppendLine("   initTest");
    	sb.AppendLine("1234 567 8910");
    	sb.AppendLine("1234 567 8910");
       	sb.AppendLine("   endTest");
    
       	sb.AppendLine("   initTest");
    	sb.AppendLine("1234 567 8911");
    	sb.AppendLine("1234 567 8911");
    	sb.AppendLine("   endTest");
    	sb.AppendLine(" ");
       	sb.AppendLine("   initTest");
    	sb.AppendLine("1234 567 8912");
    	sb.AppendLine("1234 567 8912");
    	sb.AppendLine("   endTest");
    	
    	return sb.ToString();	
    }
