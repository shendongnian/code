    public static string BuildLine(IEnumerable<string> fields)
    {
        return string.Join(",", fields.Select(WrapInQuotes));
    }
    private static string WrapInQuotes(string rawData)
    {
        return string.Format("\"{0}\"", rawData);
    }
