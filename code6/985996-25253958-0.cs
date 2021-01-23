    public static IEnumerable<string> GetMatches(string input, string regexPattern)
    {
        var _regex = new System.Text.RegularExpressions.Regex(regexPattern, RegexOptions.IgnoreCase);
        var _matches = _regex.Matches(input);
    
        return _matches.Cast<Match>()
            .Select(m => m.Value)
            .ToArray();
    }
    
    public static IEnumerable<string> GetGroups(string input, string regexPattern)
    {
        var _regex = new System.Text.RegularExpressions.Regex(regexPattern, RegexOptions.IgnoreCase);
        var _matches = _regex.Matches(input);
    
        return (from Match _m in _matches
                from Group _g in _m.Groups
                where _g.Value != _m.Value
                select _g.Value)
            .ToArray();
    }
