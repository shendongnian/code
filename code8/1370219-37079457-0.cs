    public static IEnumerable<int> GetNumbers(string text)
    {
        var match = Regex.Match(text, "^(\\[(?<number>[0-9]+)\\])*$");
        if (!match.Success)
            throw new FormatException();
        var captures = match.Groups["number"].Captures;
        foreach (Capture capture in captures)
            yield return int.Parse(capture.Value);
    }
