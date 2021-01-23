    static readonly Regex _domainMatcher =  new Regex(@"http://(www\.)?([^\.]+)\.com", RegexOptions.Compiled);
    public static bool IsValidDomain(string url)
    {
        return _domainMatcher.Match(url).Success;
    }
