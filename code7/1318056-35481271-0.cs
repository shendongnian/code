        /// <summary>
        /// Check invalid character based on the pattern
        /// </summary>
        /// <param name="text">The string</param>
        /// <returns></returns>
        public static string IsInvalidCharacters(this string text)
        {
            string pattern = @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]";
            var match = Regex.Match(text, pattern, "");
            return match.Sucess;
        }   
