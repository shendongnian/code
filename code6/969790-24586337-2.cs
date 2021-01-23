    Parse(string html)
    {
        var matches = Regex.Matches(html, yourRegexp, RegexOptions.Singleline);
        if (!matches.Any())
        {
           Console.WriteLine("CONTENT:"+html);
        }
        foreach (Match match in matches)
        {
           Console.WriteLine("OPEN:"+match.Groups["open"].Value);
           parse(match.Groups["content"].Value);
           Console.WriteLine("CLOSE:"+match.Groups["close"].Value);
        }
    }
