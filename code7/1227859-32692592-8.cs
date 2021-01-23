    public static IEnumerable<T> IntersectAll<T>(this List<List<T>> source)
    {
      if (source.Count == 0) return Enumerable.Empty<T>();
      if (source.Count == 1) return source[0];
      var set = new HashSet<T>(source[0]);
      for(int i = 1; i != source.Count; ++i)
      {
        var newSet = new HashSet<T>();
        var list = source[i];
        for(int j = 0; j != list.Count; ++j)
        {
          T item = list[j];
          if(set.Remove(item))
            newSet.Add(item);
        }
        set = newSet;
      }
      return set;
    }
