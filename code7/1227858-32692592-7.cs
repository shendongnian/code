    public static IEnumerable<T> IntersectAll<T>(this IEnumerable<IEnumerable<T>> source)
    {
      if(source == null)
        throw new ArgumentNullException("source");
      return IntersectAllIterator(source);
    }
    public static IEnumerable<T> IntersectAllIterator<T>(IEnumerable<IEnumerable<T>> source)
    {
      using(var en = source.GetEnumerator())
      {
        if(en.MoveNext())
        {
          var set = new HashSet<T>(en.Current);
          while(en.MoveNext())
          {
            var newSet = new HashSet<T>();
            foreach(T item in en.Current)
              if(set.Remove(item))
                newSet.Add(item);
            set = newSet;
          }
          foreach(T item in set)
            yield return item;
        }
      }
    }
