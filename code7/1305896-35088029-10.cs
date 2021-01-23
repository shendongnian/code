    public static int CountOccurrencesOf(this IEnumerable<string> strings,
        string character,
        StringComparison comparison = StringComparison.CurrentCulture)
    {
        return strings
            .Select(s => s.EnumerateCharacters().Count(c => String.Equals(c, character, comparison ));
    }
