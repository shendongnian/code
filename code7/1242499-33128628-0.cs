    public static float ClosestTo(this IEnumerable<float> collection, float target)
    {
        return collection
            .OrderBy(x => Math.Abs(target - x))
            .ThenByDescending(x => x)
            .First();
    }
