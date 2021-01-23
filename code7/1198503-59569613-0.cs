    public static class Date_Regex
    {
        static string DateRegex = @"\d?[\/|\-|\s]?\d?[\/|\-|\s]\d(\s?)[\/|\-|\s]?\d?(\s?)[\/|\-|\s]\d{4}[\s]?$"; 
        public static string RegexMatches(string content)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Match match in Regex.Matches(content, DateRegex, RegexOptions.Multiline)) 
            {
                sb.Append(match.Value + "; ");
            }
            return sb.ToString();
        }
    }
