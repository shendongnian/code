    public Dictionary<string, string> GetMatches(string pattern, string source)
    {
        var tokens = new List<string>();
        var matches = new Dictionary<string, string>();
        pattern = Regex.Escape(pattern);
        pattern = Regex.Replace(pattern, @"\\{.*?}", (match) =>
            {
                var name = match.Value.Substring(2, match.Value.Length - 3);
            
                tokens.add(name);
                return $"(?<{name}>.*)";
            });
        var sourceMatches = Regex.Matches(source, pattern);
        foreach (var name in tokens)
        {
            matches[name] = sourceMatches[0].Groups[name].Value;
        }
        return matches;
    }
