    public static int? FindMajorant(IList<int> numbers)
    {
        return numbers
            .GroupBy(x => x)
            .Where(g => g.Count() >= numbers.Count / 2 + 1)
            .Select(g => (int?)g.Key)
            .SingleOrDefault();
    }
