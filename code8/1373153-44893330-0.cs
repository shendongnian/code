    static IEnumerable<int> GetCodePoints(string s)
    {
        for (var i = 0; i < s.Length; i += char.IsHighSurrogate(s[i]) ? 2 : 1)
        {
            yield return char.ConvertToUtf32(s, i);
        }
    }
