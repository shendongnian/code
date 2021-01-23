    public static bool ContainsAny(this string s, IEnumerable<string> possibleContained)
    {
        foreach (string p in possibleContained)
        {
            if (s == p) return true;
            if (s == null) continue;
            if (s.Contains(p)) return true;
        }
        return false;
    }
