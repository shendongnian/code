    static IEnumerable<string> SplitString(string s, int max)
    {
        return SplitString(s, 0, max, max);
    }
    private static IEnumerable<string> SplitString(string s, int idx, int available, int maxLength)
    {
        if (idx == s.Length) yield return string.Empty;
        else
        {
            if (available > 0)
                foreach (var item in SplitString(s, idx + 1, available - 1, maxLength))
                    yield return s[idx] + item;
            if (idx > 0)
                foreach (var item in SplitString(s, idx + 1, maxLength - 1, maxLength))
                    yield return " " + s[idx] + item;
        }
    }
