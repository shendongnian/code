    // Or IsNanOrInfinity
    public static bool HasValue(this double value)
    {
        return !Double.IsNaN(value) && !Double.IsInfinity(value);
    }
