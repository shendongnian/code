            public static string UnderscoreToTitleCase(string input)
            {
                return UnderscoreToTitleCase(input, System.Globalization.CultureInfo.CurrentCulture);
            }
            public static string UnderscoreToTitleCaseInvariant(string input)
            {
                return UnderscoreToTitleCase(input, System.Globalization.CultureInfo.InvariantCulture);
            }
            public static string UnderscoreToTitleCase(string input, CultureInfo cultureInfo)
            {
                string[] words = input.Split('_');
                StringBuilder sb = new StringBuilder();
                foreach (string word in words)
                    sb.Append(cultureInfo.TextInfo.ToTitleCase(word));
                return (sb.ToString());
            }
