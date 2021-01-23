    public static IEnumerable<T> IntersectAll<T>(this IEnumerable<IEnumerable<T>> source)
    {
      using(var en = source.GetEnumerator())
      {
        if(!en.MoveNext()) return Enumerable.Empty<T>();
        var set = new HashSet<T>(en.Current);
        while(en.MoveNext())
        {
          var newSet = new HashSet<T>();
          foreach(T item in en.Current)
            if(set.Remove(item))
              newSet.Add(item);
          set = newSet;
        }
        return set;
      }
    }
