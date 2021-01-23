    // Adjust as you need to
    private static Tuple<string, int> FindFirstMatch(string text, string[] matches)
    {
        return matches.Select(match => Tuple.Create(match, text.IndexOf(match))
                      .Where(tuple => tuple.Item2 != -1)
                      .OrderBy(tuple => tuple.Item2)
                      .FirstOrDefault();
    }
