    public static IEnumerable<Tuple<int, int>> Runs(this IEnumerable<int> nums)
    {
        int? prev = null;
        int group = 0;
        return nums.OrderBy(n => n)
            .Select(
                n =>
                {
                    if (prev.HasValue && n - prev.Value > 1) { group++; }
                    prev = n;
                    return new { group, num = n };
                })
            .GroupBy(x => x.group)
            .Select(g => new Tuple<int, int>(g.Min(x => x.num), g.Max(x => x.num)));
    }
