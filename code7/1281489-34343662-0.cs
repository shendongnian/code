    internal static class DictionaryHelper
    {
        /// <summary>
        /// Returns a string of key value pairs in the format k1=v1,k2=v2,...
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string ToKeyValueString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            return ToKeyValueString(dictionary, "{0}={1}", ",");
        }
        
        /// <summary>
        /// Returns a string of key value paris in the format k1=v1{separator}kk2=v2...
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="seperator">The string separator for the pairs</param>
        /// <returns></returns>
        public static string ToKeyValueString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, string seperator)
        {
            return ToKeyValueString(dictionary, "{0}={1}", seperator);
        }
        /// <summary>
        /// Returns a string of key value pairs in the specified format with the specified separator
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="format">The format string for the key value pairs</param>
        /// <param name="separator">The string separator for the pairs</param>
        /// <returns></returns>
        public static string ToKeyValueString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, string format, string separator)
        {
            var pairs = dictionary.Select(c => string.Format(format, c.Key, c.Value));
            return string.Join(separator, pairs);
        }
    }
