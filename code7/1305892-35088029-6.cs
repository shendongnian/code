    public static int CountMaximumOccurrencesOf(this IEnumerable<string> strings, string c)
    {
        return strings
            .Select(s => s.GetCharactersInString().Count(x => String.Equals(x, c))
            .Max();
    }
