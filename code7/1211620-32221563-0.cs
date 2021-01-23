    public string MiddleLettersOf(string s)
    {
        if (s.Length == 0)
            return "";
        if ((s.Length & 1) == 1) // Odd length?
            return s.Substring(s.Length/2, 1);
        return s.Substring(s.Length/2-1, 2);
    }
