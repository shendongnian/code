    public static class StringExt
    {
        public static string Remove(this string self, params char[] charsToRemove)
        {
            var result = new StringBuilder();
            foreach (char c in self)
                if (Array.IndexOf(charsToRemove, c) == -1)
                    result.Append(c);
            return result.ToString();
        }
    }
