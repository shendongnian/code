    private static string ExtractJist(string freeText)
    {
    StringBuilder patternBuilder = new StringBuilder();
    patternBuilder.Append(@"Name: (?<name>.*$)\n").Append("Value: (?<value>.*$)\n");
    Match match = Regex.Match(freeText, patternBuilder.ToString(), RegexOptions.Multiline | RegexOptions.IgnoreCase);
    string name= match.Groups["name"].ToString();
    string value= match.Groups["value"].ToString();
    return string.Concat(name, "|", value);
    }
