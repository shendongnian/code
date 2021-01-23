    public IEnumerable<string> Tokenise()
    {
        var input = "Mainframes/pl/ sql; Software Testing/PL/SQL/Project management/";
        var results = new List<string>();
        
        foreach (Match match in Regex.Matches(input, @"pl\s*/\s*sql", RegexOptions.IgnoreCase))
        {
            results.Add(match.Value);
        }
        
        input = Regex.Replace(input, @"pl\s*/\s*sql", string.Empty, RegexOptions.IgnoreCase);
        
        results.AddRange(input.Split(new []{'/'}, StringSplitOptions.RemoveEmptyEntries));
    
        return results;
    }
