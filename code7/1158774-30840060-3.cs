    private static List<string> GetContents(string input, string pattern)
    { 
        MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Singleline); 
        List<string> contents = new List<string>(); 
        foreach (Match match in matches) 
        contents.Add(match.Value); 
        return contents; 
    }
