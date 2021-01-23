    public static class StringExtensions
    {
        public static bool IsNumeric(this string input)
        {
            int number;
            return int.TryParse(input, out number);
        }
    }
