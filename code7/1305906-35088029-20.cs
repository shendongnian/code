    private static IEnumerable<string> EnumerateCharacters(string s)
    {
        var enumerator = StringInfo.GetTextElementEnumerator(s.Normalize());
        while (enumerator.MoveNext())
            yield return (string)enumerator.Value;
    }
