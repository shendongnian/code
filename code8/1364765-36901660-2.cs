    public static IEnumerable<string> Combinations(string s, Dictionary<char, char> replacements)
    {
        return Combinations(s, replacements, 0, string.Empty);
    }
    public static IEnumerable<string> Combinations(string original, Dictionary<char, char> replacements, int index, string current)
    {
        if (index == original.Length) yield return current;
        else
        {
            foreach (var item in Combinations(original, replacements, index + 1, current + original[index]))
                yield return item;
            if (replacements.ContainsKey(original[index]))
                foreach (var item in Combinations(original, replacements, index + 1, current + replacements[original[index]]))
                    yield return item;
        }
    }
