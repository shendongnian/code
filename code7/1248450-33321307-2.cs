    public static IEnumerable<string> ExtractDomains(string data)
    {
        var result = new List<string>();
        var match = _domainMatcher.Match(data);
        while (match.Success)
        {
            result.Add(match.Value);
            match = match.NextMatch();
        }
        return result;
    }
