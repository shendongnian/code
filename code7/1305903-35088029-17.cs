    public static int CountMaximumOccurrencesOf(this IEnumerable<string> strings, string character)
    {
        return strings
            .Select(s => s.EnumerateCharacters().Count(c => String.Equals(c, character, StringComparison.CurrentCulture))
            .Max();
    }
