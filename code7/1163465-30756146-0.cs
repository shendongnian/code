    public static void Highlitor(string text, IEnumerable<string> replaceStrings)
    {
        foreach(string repl in replaceStrings.Distinct())
        {
            string replWith = string.Format("<span class='highlight-text'>{0}</span>", repl);
            text = text.Replace(repl, replWith);
        }
    }
