    private static string ReplaceCaseInsensitive(string input, string search, string replacement)
    {
        string result = Regex.Replace(
            input,
            Regex.Escape(search), 
            replacement.Replace("$","$$"), 
            RegexOptions.IgnoreCase
        );
        return result;
    }
