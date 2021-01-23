    public static int CountOccurrencesOf(this IEnumerable<string> strings,
        string character,
        StringComparison comparison = StringComparison.CurrentCulture)
    {
        Debug.Assert(character.EnumerateCharacters().Count() == 1);
        return strings
            .Select(s => s.EnumerateCharacters().Count(c => String.Equals(c, character, comparison ));
    }
