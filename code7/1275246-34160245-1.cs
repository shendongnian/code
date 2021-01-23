    "testing one translation"
        .Split(' ')
        .Select(word => word.ToCharsWithStartingVowelLast())
        .Select(word => word.WithEnding("way"))
        .Select(word => string.Concat(word))
        .Join(' ');
    static class Extensions {
        public static IEnumerable<char> ToCharsWithStartingVowelLast(this string word)
        {
            return "aeiouy".Contains(word[0])
                ? word.Skip(1).Concat(new[] {word[0]})
                : word.ToCharArray();
        }
        public static IEnumerable<char> WithEnding(this IEnumerable<char> word, string ending)
        {
            return word.Concat(ending.ToCharArray())
        }
        public static string Join(this IEnumerable<IEnumerable<char>> words, char separator)
        {
            return string.Join(separator, words.Select(word => string.Concat(word)));
        }
    }
