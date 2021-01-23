            /// <summary>
        /// Return a CSV string of the values in the list
        /// </summary>
        /// <param name="intValues"></param>
        /// <param name="separator"></param>
        /// <param name="encloser"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToCSV<T>(this IEnumerable<T> intValues, string separator = ",", string encloser = "")
        {
            string result = String.Empty;
            foreach (T value in intValues)
            {
                result = String.IsNullOrEmpty(result)
                    ? string.Format("{1}{0}{1}", value, encloser)
                    : String.Format("{0}{1}{3}{2}{3}", result, separator, value, encloser);
            }
            return result;
        }
