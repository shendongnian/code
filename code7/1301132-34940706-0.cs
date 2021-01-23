    string pattern = @"[\u0020-\u007E]";
    Regex rgx = new Regex(pattern);
    List<string> matches = new List<string> ();
    
    foreach (Match match in rgx.Matches(str))
    {
        if (!matches.Contains (match.Value))
        {
            matches.Add (match.Value);
        }
    }
         
