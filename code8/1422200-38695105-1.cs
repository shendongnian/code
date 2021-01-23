    public static List<string> GetTokens(this string line)
    {
        return Regex.Matches(line,
            @""".*?""|\S+").Cast<Match>().Select(m => m.Value).ToList();
    }
