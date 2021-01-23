    public static string NullSafeToLower(this string s)
    {
        if (s == null)
        {
            s = string.Empty;
        }
        return s.ToLower();
    }
