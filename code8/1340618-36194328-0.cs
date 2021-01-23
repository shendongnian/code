    public static IEnumerable<string> EnumerateHyphenatedStrings(string s)
    {
        string[] parts = s.Split('-');
        int n = parts.Length - 1;
        if (n > 30) throw new Exception("too many hyphens");
        for (int m = (1 << n) - 1; m >= 0; m--)
        {
            StringBuilder sb = new StringBuilder(parts[0]);
            for (int i = 1; i <= n; i++)
            {
                if ((m & (1 << (i - 1))) > 0) sb.Append('-');
                sb.Append(parts[i]);
            }
            yield return sb.ToString();
        }
    }
