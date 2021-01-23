     public static string Highlitor(string text, IEnumerable<string> replaceStrings)
    {
        string result = text;
        foreach (string repl in replaceStrings.Distinct())
        {
            string replWith = string.Format("<span class='highlight-text'>{0}</span>", repl);
            result = ReplaceCaseInsensitive(result, repl, replWith, true);
        }
        return result;
    }
