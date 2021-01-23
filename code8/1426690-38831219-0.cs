    public static class StringExtensions
    {
        public static IsNumeric(this string @this)
        {
            int number;
            return int.TryParse(@this, out number);
        }
    }
