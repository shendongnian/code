    public static class Helper
    {
        public static string MyExtract(this string s)
        {
            return s.Split(',').First(str => Regex.IsMatch(str, @"[0-9.,]"));
        }
    }
