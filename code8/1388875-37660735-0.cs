    public static class RoundingExtentionMethod
    {
            public static int ToIntegerPercentage(this decimal d)
            {
                return Convert.ToInt32(Math.Round(d, 0, MidpointRounding.AwayFromZero));
            }
    }
