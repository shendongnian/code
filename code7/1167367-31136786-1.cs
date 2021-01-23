    public static class StringExtension
    {
        public static string ReplaceNewLine(this string s, string c = "|")
        {
            return s.Replace(c, Environment.NewLine);
        }
    }
