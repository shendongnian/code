    internal static class ToLowerEx
    {
        static readonly Regex Words = new Regex(@"(?'item'\b\w+\b)|(?'item'\b\W+\b)", RegexOptions.ExplicitCapture);
        public static string Get(string text)
        {
            if (!Words.IsMatch(text)) return text;
            var result = new StringBuilder();
            var matches = Words.Matches(text);
            foreach (Match match in matches)
                result.Append(ProcessWord(match.Value));
            return result.ToString();
        }
        private static string ProcessWord(string text)
        {
            return !text.All(char.IsUpper)
                ? text.ToLower()
                : text;
        }
    }
