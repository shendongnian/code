    public static class DateTimeExtensions
    {
        public static bool IsValidTimeFormat(this string input)
        {
            TimeSpan dummyOutput;
            return TimeSpan.TryParse(input, out dummyOutput);
        }
    }
