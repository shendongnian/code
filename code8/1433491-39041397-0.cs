    public static class StringExt
    {
        public static IEnumerable<char> SelectOnlyVowels(this string self)
        {
            return self.Where(c => "aeiou".Contains(char.ToLower(c)));
        }
    }
