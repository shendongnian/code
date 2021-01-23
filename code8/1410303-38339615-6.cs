    public static bool ContainsAny(this string self, params string[] criteria)
    {
        foreach (string s in criteria)
        {
            if (self.Contains(s))
            {
                return true;
            }
        }
        return false;
    }
