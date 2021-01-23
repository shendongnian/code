    private const string SPLIT_FORMAT = "{0}(?=(?:[^']*'[^']*')*[^']*$)";
    public static string SplitOutsideSingleQuotes(this string text, char splittingChar)
    {
        string[] parts = Regex.Split(text, String.Format(SPLIT_FORMAT, splittingChar), RegexOptions.None);
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = parts[i].Replace("'", "");
        }
        return String.Join("", parts);
    }
