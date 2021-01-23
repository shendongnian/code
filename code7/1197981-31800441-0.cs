        public static string VariablesToUpperCase(this string input)
        {
            return Regex.Replace(input, @"\[\w+\]", delegate (Match match)
            {
                string v = match.ToString();
                return v.ToUpper();
            });
        }
