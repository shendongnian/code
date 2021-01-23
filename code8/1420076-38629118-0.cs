    public static string RemoveDuplicates(this string s)
    {
        if (String.IsNullOrEmpty(s)) return String.Empty(); // optional: return null
        var resultBuilder = new StringBuilder(s.Length);
        resultBuilder.Append(s.First());
        for (int i=1; i< s.Length; ++i)
        {
            if (s[i] != s[i-1])
                resultBuilder.Append(s[i]);
        }
        return resultBuilder.ToString();
    }
