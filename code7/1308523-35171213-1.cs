     /// <summary>
            /// Parses the input string and returns <see cref="System.DateTime"/> if the input is a valid 
            /// representation of a date. Otherwise it returns <c>null</c>.
            /// </summary>
            public static DateTime? GetDateTimeFromString(string raw)
            {
                DateTime result;
                if (!DateTime.TryParse(raw, out result))
                {
                    return null;
                }
                return result;
            }
