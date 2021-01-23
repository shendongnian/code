    public static class MyOperations
    {
    
    public static string Pattern = @"https?://(www\.)?(?<Url>[^\s]+)";
    public static Regex RegexHTTP = new Regex(Pattern, RegexOptions.ExplicitCapture);
    
    public static IEnumerable<string> GetUrl(this string text)
    {
        return RegexHTTP.Matches(text)
                        .OfType<Match>()
                        .Select (mt => mt.Groups["Url"].Value);
    }
        
    public static IEnumerable<string> GetUrlEx(this string text)
    {
        var urls = RegexHTTP.Matches(text)
                        .OfType<Match>()
                        .Select (mt => mt.Groups["Url"].Value);
    
        foreach (var url in urls)
            yield return url;
    
    }
