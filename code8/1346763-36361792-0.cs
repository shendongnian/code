    private static IEnumerable<string> InsertBetween(
        this IList<string> words, 
        char[] characters, 
        string insertValue)
    {
        for (int i = 0; i < words.Count - 1; i++)
        {
            yield return words[i];
            if (characters.Contains(words[i].Last()) && characters.Contains(words[i + 1][0]))
                yield return insertValue;
        }
        if (words.Count > 0)
            yield return words[words.Count - 1];
    } 
