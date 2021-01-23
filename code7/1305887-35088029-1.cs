    public static int CountMaximumOccurrencesOf(this IEnumerable<string> strings, char c)
    {
        return strings
            .Select(s => s.Count(x => x == c))
            .Max();
    }
