    static class DateParser
    {
        private static readonly Regex DateRegex = new Regex(@"\d{1,2}/\d{1,2}/\d{4}");
        public static DateTime Parse(string value)
        {
            if (!DateRegex.IsMatch(value)) throw new DateFormatException();
            return DateTime.Parse(value);
        }
    }
    internal class DateFormatException : Exception
    {
    }
