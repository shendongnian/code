    static string FixHyperlinks(string source)
    {
        const string pattern = "HYPERLINK \"(.+)\"";
        return Regex.Replace(source, pattern, "");
    }
