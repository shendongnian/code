    public static class Base36Converter
    {
        private const string Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string ConvertTo(int value)
        {
            string result = "";
            while (value > 0)
            {
                result += Chars[value % 36];
                value /= 36;
            }
            return result;
        }
    }
