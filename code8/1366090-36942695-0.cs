    public static IEnumerable<IEnumerable<T>> Chunk(
      this IEnumerable<T> items, int size) 
    {
      return items
        .Select((item, index) => new { Group = index / size, Item = item })
        .GroupBy(x => x.Group)
        .Select(group => group.Select(g => g.Item));
    }
