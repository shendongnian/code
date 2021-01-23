    public static IEnumerable<int> FindClosest(int[] array, int target)
    {
        return Combinations(array)
            .Where(c => c.Sum() >= target)
            .MinByOrDefault(c => c.Sum());
    }
