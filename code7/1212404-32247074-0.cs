    private static readonly Regex RemovalRegex = new Regex(@"\s|[().]");
    ...
    public static string RemoveUnwantedCharacters(string input)
    {
        return RemovalRegex.Replace(input, "");
    }
