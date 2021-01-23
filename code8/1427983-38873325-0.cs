    public static class IntExtensions
    {
        public static bool Between(this int value, int lowerBound, int upperBound)
        {
            return value >= lowerBound && value <= upperBound;
        }
    }
