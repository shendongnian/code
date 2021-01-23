    public static class DecimalExtensions
    {
        public static decimal? ToMegaBytes(this decimal? value)
        {
            if (value != null)
            {
                return value / 1024;
            }
            return null;
        }
    }
