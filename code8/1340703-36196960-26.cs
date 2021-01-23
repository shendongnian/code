    public static IEnumerable<int> FindClosest(int[] array, int target)
    {
        var result = Combinations(array).MinBy(c => {
            int s = c.Sum();
            return s >= target ? s : int.MaxValue; });
        return result.Sum() >= target ? result : Enumerable.Empty<int>();
    }
