    public string GetPrefix(string url)
    {
        Regex regex = new Regex(@"^/(?<action>[^/?#]+)");
        var match = regex.Match(url);
        return match.Groups["action"].Value;
    }
