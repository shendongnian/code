    public static class Extensions
    {
        public static string CustomPadLeft(this string input, int padLength, char padChar)
        {
            if (padLength == 0)
            {
                return string.Empty;
            }
            return input.PadLeft(padLength, padChar);
        }
    }
