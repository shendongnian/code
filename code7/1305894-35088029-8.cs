    private static IEnumerable<string> EnumerateCharacters(string s)
    {
        var enumerator = StringInfo.GetTextElementEnumerator(s);
        while (enumerator.MoveNext())
            yield return (string)enumerator.Value;
    }
