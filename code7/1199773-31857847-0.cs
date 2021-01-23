    public static IEnumerable<T> FilteredMatches<T>(Func<T, bool> predicate, int maxElements, params List<T>[] lists)
    {
      return FilteredMatches<T>(predicate, maxElements, (IEnumerable<List<T>>)lists);
    }
    public static IEnumerable<T> FilteredMatches<T>(Func<T, bool> predicate, int maxElements, IEnumerable<List<T>> lists)
    {
      if(maxElements > 0)
      {
        var found = new HashSet<T>();
        foreach(var list in lists)
          foreach(var item in list)
            if(predicate(item) && found.Add(item))
            {
              yield return item;
              if(--maxElements == 0)
                yield break;
            }
      }
    }
