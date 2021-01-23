    public static IEnumerable<string> ExtractDomains(string data)
    {
        var match = _domainMatcher.Match(data);
        while (match.Success)
        {
            yield return match.Value;
            match = match.NextMatch();
        }
    }
