        private static string Linq2SqlConvertToEntityFramework(string originalQuery)
        {
            // Finds expressions with .Add____)
            const string dateTimeAdditationPattern = @"(@?[a-z_A-Z]\w*(?:\.@?[a-z_A-Z]\w*)*).Add\s*.+?(?=\))\)";
            // Finds all the matches
            var matchces = Regex.Matches(originalQuery, dateTimeAdditationPattern);
            // Enumerates all the matches, and creates a patch
            foreach (Match m in matchces)
            {
                var inputValue = m.Value;
                string valuePassed = inputValue.Between("(", ")").Trim();
                string typeOfAddition = inputValue.Between(".Add", "(").Trim();
                string dateTimeExpression = inputValue.Before(".Add").Trim();
                // because DateTime.AddMinutes()  (or any other AddXXX(Y) accepts a double, and 
                // DbFunctions only accepts an int,
                // We must move this to milliseconds so we dont lose any expected behavior
                // The input value could be an int or a input variable (such as a sub query)
                var mutipler = 1;
                switch (typeOfAddition)
                {
                    case "Seconds":
                        mutipler = 1000;
                        break;
                    case "Minutes":
                        mutipler = 1000*60;
                        break;
                    case "Hours":
                        mutipler = 1000 * 60 * 60;
                        break;
                    case "Days":
                        mutipler = 1000 * 60 * 60 * 24;
                        break;
                }
                // new expression to work with Entity Framework
                var replacementString = string.Format("DbFunctions.AddMilliseconds({0},(int)({1} * {2}))", dateTimeExpression, valuePassed, mutipler);
                // Simple string replace for the input string
                originalQuery = originalQuery.Replace(inputValue, replacementString);
            }
            return originalQuery;
        }
        /// <summary>
        /// Get string value between [first] a and [last] b.
        /// Credit Source: http://www.dotnetperls.com/between-before-after
        /// </summary>
        public static string Between(this string value, string a, string b)
        {
            int posA = value.IndexOf(a, StringComparison.InvariantCulture);
            int posB = value.LastIndexOf(b, StringComparison.InvariantCulture);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }
        /// <summary>
        /// Get string value after [first] a.
        /// Credit Source: http://www.dotnetperls.com/between-before-after
        /// </summary>
        public static string Before(this string value, string a)
        {
            int posA = value.IndexOf(a, StringComparison.InvariantCulture);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }
        /// <summary>
        /// Get string value after [last] a.
        /// Credit Source: http://www.dotnetperls.com/between-before-after
        /// </summary>
        public static string After(this string value, string a)
        {
            int posA = value.LastIndexOf(a, StringComparison.InvariantCulture);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }
