    public static int CountMaximumOccurrencesOf(this IEnumerable<string> strings, char ch)
    {
        return strings
            .Select(s => s.Count(c => c == ch))
            .Max();
    }
