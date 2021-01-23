    public static IEnumerable<int> FindClosest(int[] array, int target)
    {
        return Combinations(array)
            .Select(c => new {S = c.Sum(), C = c})
            .Where(c => c.S >= target)
            .MinByOrDefault(x => x.S)
            ?.C;
    }
