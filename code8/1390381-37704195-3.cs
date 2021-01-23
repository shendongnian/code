    public static int MaxSubstringLength(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;
        int max = 0, cur = s.Length > 0 ? 1 : 0;
        for (int i = 1; i < s.Length; ++i, ++cur)
        {
            if (s[i] != s[i-1] || (i == s.Length))
            {
                max = cur > max ? cur : max;
                cur = 0;
            }
        }
        return cur > max ? cur : max;
    }
