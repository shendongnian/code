    private static IEnumerable<byte> StripBlocksWithZeroes(IEnumerable<byte> input)
    {
        IEnumerable<byte> stripped = input
            .Select((b, i) => new { Byte = b, Index = i })
            .GroupBy(x => x.Index / 8)
            .Where(g => g.All(x => x.Byte != 0))
            .SelectMany(g => g.Select(x => x.Byte))
            .ToList();
        return stripped;
    }
