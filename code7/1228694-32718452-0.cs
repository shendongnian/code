    public static class MyNullableDecimalExtensions
    {
        public static string ToDisplayText(this decimal? value)
        {
            if (decimal.HasValue)
                return decimal.Value.ToString();
            return "N/A";
        }
    }
