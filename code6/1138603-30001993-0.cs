    public static bool SomeButNotAll<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
    {
      if(source == null)
        throw new ArgumentNullException("source");
      if(predicate == null)
        throw new ArgumentNullException("predicate");
      return source.
        Select(predicate)
        .Distinct()
        .Take(2)
        .Count() == 2;
    }
    public static bool SomeButNotAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
      if(source == null)
        throw new ArgumentNullException("source");
      if(predicate == null)
        throw new ArgumentNullException("predicate");
      using(var en = source.GetEnumerator())
        if(en.MoveNext())
        {
          bool first = predicate(en.Current);
          while(en.MoveNext())
            if(predicate(en.Current) != first)
              return true;
        }
      return false;
    }
