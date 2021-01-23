    var matches = new List<string>();
    var regex = new Regex(@"^([^:]+):[ \t]+(.*?)[ \t]*$", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
    var matchResult = regex.Match(File.ReadAllText("TextFile1.txt"));
    while (matchResult.Success)
    {
        matches.Add(matchResult.Groups[1].Value);
        matches.Add(matchResult.Groups[2].Value);
        matchResult = matchResult.NextMatch();
    } 
