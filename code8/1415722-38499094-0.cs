    public static class StringExtension
    {
        /// <summary>
        /// Trim space at the end of string for count times
        /// </summary>
        /// <param name="input"></param>
        /// <param name="count">number of space at the end to trim</param>
        /// <returns></returns>
        public static string TrimEnd(this string input, int count = 1)
        {
            string result = input;
            if (count <= 0)
            {
                return result;
            }
            if (result.EndsWith(new string(' ', count)))
            {
                result = result.Substring(0, result.Length - count);
            }
            return result;
        }
        /// <summary>
        /// Trim space at the start of string for count times
        /// </summary>
        /// <param name="input"></param>
        /// <param name="count">number of space at the start to trim</param>
        /// <returns></returns>
        public static string TrimStart(this string input, int count = 1)
        {
            string result = input;
            if (count <= 0)
            {
                return result;
            }
            if (result.StartsWith(new string(' ', count)))
            {
                result = result.Substring(count);
            }
            return result;
        }
    }
