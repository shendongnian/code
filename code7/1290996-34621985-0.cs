    string contents = " testing NewFinancial History:\"xyz\"   ";
    var keys = Regex.Matches(contents, @"New(.+?):", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace).OfType<Match>().Select(m => m.Groups[0].Value.Trim().Replace(":", "")).Distinct().ToArray();
    
    foreach (string key in keys)
    {
        List<string> valueList = new List<string>();
        string listNameKey = key;
        string regex = "" + listNameKey + ":" + "\"([^\"]*)\"";  //create an anonymous capture group
    
        var matches = Regex.Matches(contents, regex, RegexOptions.Singleline);
        foreach (Match match in matches)
        {
            if (match.Success)
            {                    
                string value = match.Groups[0].Value; //get the first group
                valueList.Add(value);
            }            
        }
    }
