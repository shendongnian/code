     public static IEnumerable<char> ToCharsWithStartingConsonantsLast(this string word)
    {
        return word.SkipWhile(c => c.IsConsonant()).Concat(word.TakeWhile(c => c.IsConsonant()));
    }
    public static bool IsConsonant(this char c)
    {
        return !"aeiouy".Contains(c);
    }
