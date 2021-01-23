    public IEnumerable<int> Randomize(int count, int seed)
    {
        var generator = new Random(seed);
        return Enumerable.Range(0, 100)
          .Select(x => new { Value = x, SortOrder = generator.Next() })
          .OrderBy(x => x.SortOrder)
          .Select(x => x.Value)
          .Take(count);
    }
