    static bool IsAnagrammaticPair(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        var l1 = s1.ToLookup(c => c);
        return s2.GroupBy(c => c).All(g => l1.Contains(g.Key) && l1[g.Key].Count() == g.Count());
    }
