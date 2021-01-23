    public static class StringExtentions
    {
        public static List<string> findWords(this string str, List<string> words)
        {
            return words.Where(str.Contains).ToList();
        }
    }
