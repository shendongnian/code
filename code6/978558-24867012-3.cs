    public static string GetLongestCommonPrefix(string[] s)
    {
        int k = s[0].Length;
        for (int i = 1; i < s.Length; i++)
        {
            k = Math.Min(k, s[i].Length);
            for (int j = 0; j < k; j++)
                if (s[i][j] != s[0][j])
                {
                    k = j;
                    break;
                }
        }
        return s[0].Substring(0, k);
    }
 
