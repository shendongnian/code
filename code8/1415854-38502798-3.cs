    public static IEnumerable<T[]> SplitArrayWithLinq<T>(T[] source, int size) {
      if (null == source)
        throw new ArgumentNullException("source");
      else if (size <= 0)
        throw new ArgumentOutOfRangeException("size", "size must be positive");
      return Enumerable
        .Range(0, source.Length / size + (source.Length % size > 0 ? 1 : 0))
        .Select(index => source
          .Skip(size * index)
          .Take(size)
          .ToArray());
    }
