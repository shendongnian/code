    public static int Search(string text, string pattern, bool once = false)
    {
        var result = 0;
        var concat = pattern + "$" + text;
        var l = concat.Length;
        var n = pattern.Length;
        var za = new int[l];
        GetZarray(concat, za);
        for (var i = 0; i < l; ++i)
        {
            if (za[i] == n)
            {
                Console.WriteLine("Pattern found at index: {0}", i - n - 1);
                result ++;
                if (once) break;
            }
        }
        return result;
    }
    private static void GetZarray(string str, int[] za)
    {
            var n = s.Length;
            var l = 0;
            var r = 0;
            for (var i = 1; i < n; ++i)
            {
                if (i <= r) z[i] = Math.Min(r - i + 1, z[i - l]);
                while (i + z[i] < n && s[z[i]] == s[i + z[i]]) ++z[i]; 
                if (i + z[i] - 1 <= r) continue;
                l = i;
                r = i + z[i] - 1;
            }
    }
