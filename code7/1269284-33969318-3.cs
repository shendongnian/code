    public static string Method(string input)
    {
        var matches = Regex.Matches(input, @"\/?(.+?)\/");
        if (matches.Count == 0) return input;
        return matches[0].Groups[1].Value;
    }
