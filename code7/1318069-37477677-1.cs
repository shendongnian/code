    public static class TxService
    {
        #region UAT overloads
        /// <summary>
        /// Combined abbreviation for the UpperCase and Text methods.
        /// </summary>
        public static string UAT(string key)
        {
            return UA(Tx.T(key));
        }
        /// <summary>
        /// Combined abbreviation for the UpperCase and Text methods.
        /// </summary>
        public static string UAT(string key, int count)
        {
            return UA(Tx.T(key, count));
        }
        /// <summary>
        /// Combined abbreviation for the UpperCase and Text methods.
        /// </summary>
        public static string UAT(string key, decimal count)
        {
            return UA(Tx.T(key, count));
        }
        /// <summary>
        /// Combined abbreviation for the UpperCase and Text methods.
        /// </summary>
        public static string UAT(string key, params string[] data)
        {
            return UA(Tx.T(key, data));
        }
        /// <summary>
        /// Combined abbreviation for the UpperCase and Text methods.
        /// </summary>
        public static string UAT(string key, Dictionary<string, string> data)
        {
            return UA(Tx.T(key, data));
        }
        /// <summary>
        /// Combined abbreviation for the UpperCase and Text methods.
        /// </summary>
        public static string UAT(string key, int count, params string[] data)
        {
            return UA(Tx.T(key, count, data));
        }
        /// <summary>
        /// Combined abbreviation for the UpperCase and Text methods.
        /// </summary>
        public static string UAT(string key, int count, Dictionary<string, string> data)
        {
            return UA(Tx.T(key, count, data));
        }
        /// <summary>
        /// Combined abbreviation for the UpperCase and Text methods.
        /// </summary>
        public static string UAT(string key, decimal count, params string[] data)
        {
            return UA(Tx.T(key, count, data));
        }
        /// <summary>
        /// Combined abbreviation for the UpperCase and Text methods.
        /// </summary>
        public static string UAT(string key, decimal count, Dictionary<string, string> data)
        {
            return UA(Tx.T(key, count, data));
        }
        #endregion UT overloads
        /// <summary>
        /// Abbreviation for the <see cref="UpperCaseAll"/> method.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string UA(string text)
        {
            return UpperCaseAll(text);
        }
        /// <summary>
        /// Transforms the first character of a text to upper case.
        /// </summary>
        /// <param name="text">Text to transform.</param>
        /// <returns></returns>
        public static string UpperCaseAll(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return text.ToUpper();
        }
    }
