    public static IEnumerable<string> Split(this string value, int desiredLength)
    {
        var characters = StringInfo.GetTextElementEnumerator(value);
        while (characters.MoveNext())
            yield return String.Concat(Take(characters, desiredLength));
    }
    
    private static IEnumerable<string> Take(TextElementEnumerator enumerator, int count)
    {
        for (int i = 0; i < count; ++i)
        {
            yield return (string)enumerator.Current;
    
            if (!enumerator.MoveNext())
                yield break;
        }
    }
