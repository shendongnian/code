    public static class RoundingExtentionMethod
    {
        public static int ToIntegerPercentage(this decimal d)
        {
            return Convert.ToInt32(Math.Ceiling(Math.Round (d, 2, MidpointRounding.AwayFromZero)));
        }
    }
