     public static string VariablesToUpperCase(this string input)
        {
            string pattern = @"\[\w+\]";
            Regex rgx = new Regex(pattern);
            return rgx.Replace(input, (m) => { return m.ToString().ToUpper(); });
        }
