    string text = File.ReadAllText(@"test.html"); // Or any way getting your html string
    string pattern = "<span class=\"username\">(?<after>[\\w ]+)";
    MatchCollection matches = Regex.Matches(text, pattern);
    
    for (int i = 0; i < matches.Count; i++)
    {
    	Console.WriteLine("Username:" + matches[i].Groups["after"].ToString());
    }
