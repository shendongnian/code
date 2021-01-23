    public parser(string text)
    {
        string pattern = @"(^|[\r\n])(\w{1,3} )?(11|\d): (?<line>[^\r\n]+)(\r?\n\s+(?<line>[^\r\n]+))*";
        var entries = new List<string>();
        foreach (Match m in Regex.Matches(text, pattern))
            if(m.Success)
                entries.Add(string.Join(" ", 
                    m.Groups["line"].Captures.Cast<Capture>().Select(x=>x.Value)));
        _text = entries.ToArray();
    }
