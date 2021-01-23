    public static string RegexReplacer(Match match)
    {
        object obj = Eval(match.Groups[2].Value);
        return obj != null ? obj.ToString() : string.Empty;
    }
