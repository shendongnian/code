    static string FixHyperlinks(string source)
    {
        const string pattern = "HYPERLINK \"([^\"]+)\"";
        return Regex.Replace(source, pattern, m => m.Groups[1].Value);
    }
