        public static IEnumerable<string> SplitEmailsByDelimiter(string input, char delimiter)
        {
            var emails = new List<string>();
            int startIndex = 0;
            var delimiterIndex = 0;
            while (delimiterIndex >= 0)
            {
                delimiterIndex = input.IndexOf(';', startIndex);
                string substring = input;
                if (delimiterIndex > 0)
                {
                    substring = input.Substring(0, delimiterIndex);
                }
                if (!substring.Contains("\"") || substring.IndexOf("\"") != substring.LastIndexOf("\""))
                {
                    yield return substring;
                    input = input.Substring(delimiterIndex + 1);
                    startIndex = 0;
                }
                else
                {
                    startIndex = delimiterIndex + 1;
                }
            }
        }
