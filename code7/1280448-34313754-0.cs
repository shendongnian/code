        public static class StringExtensions
        {
            public static string ReplaceAllOccurrences(
                this string str,
                string oldValue,
                string newValue)
            {
                var stringBuilder = new StringBuilder(str);
                return stringBuilder.Replace(oldValue, newValue).ToString();
            }
        }
