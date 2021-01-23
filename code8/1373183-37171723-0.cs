    public static string[] ValidatePattern(string pattern, string input, List<string> groupNames)
    {
        Regex regex = new Regex(pattern);
        var matches = regex.Matches(input);
    
        List<string> results = new List<string>();
        foreach (Match match in matches) {
            foreach (var name in groupNames)
            {
                var group = match.Groups[name];
                results.Add(group.Success ? group.Value : string.Empty);
            }
        }
        return results.ToArray();
    }
