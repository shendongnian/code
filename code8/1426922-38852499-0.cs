    static bool IsAnagrammaticPair(string s1, string s2)
    {
        var srt1 = s1.OrderBy(c => c);
        var srt2 = s2.OrderBy(c => c);
        return s1.SequenceEqual(s2);
    }
