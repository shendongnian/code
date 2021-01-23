    public static class StringExtensions
    {
        public static IsNumeric(this string input)
        {
            int number;
            return int.TryParse(input, out number);
        }
    }
