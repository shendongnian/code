    public static string ExtractDomain(string url)
    { 
        var match = _domainMatcher.Match(url);
        if(match.Success)
            return match.Value;
        else
            return string.Empty;
    }
