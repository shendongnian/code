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
                result += n;
                if (once) break;
            }
        }
        return result;
    }
    private static void GetZarray(string str, int[] za)
    {
        var n = str.Length;
        for (var i = 1; i < n; ++i)
        {
            var l = 0;
            var r = 0;
            if (i > r)
            {
                l = r = i;
                while (r < n && str[r - l] == str[r]) r++;
                za[i] = r - l;
            }
            else
            {
                var k = i - l;
                if (za[k] < r - i + 1) za[i] = za[k];
                else
                {
                    l = i;
                    while (r < n && str[r - l] == str[r]) r++;
                    za[i] = r - l;
                }
            }
        }
    }
