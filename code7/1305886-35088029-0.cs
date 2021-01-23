    public static int CountMaximumOccurrencesOf(this IEnumerable<string> strings, char c)
    {
        return strings
            .Select(x => x.Count(x => x == c))
            .Max();
    }
