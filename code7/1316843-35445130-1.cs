    public static string Parse(this string s, string first, string second)
    {
        try
        {
            if (string.IsNullOrEmpty(s)) return "";
            var start = s.IndexOf(first, StringComparison.InvariantCulture) + first.Length;
            var end = s.IndexOf(second, start, StringComparison.InvariantCulture);
            var length = end - start;
            return (end > 0 && length < s.Length) ? s.Substring(start, length) : s.Substring(start);
        }
        catch (Exception) { return ""; }
    }
