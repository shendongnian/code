    public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      /* do null checks */
      using(var en = source.GetEnumerator())
        while(en.MoveNext())
        {
          var val = en.Current;
          if(predicate(val))
          {
            while(en.MoveNext())
              if(predicate(en.Current))
                throw new InvalidOperationException("too many matching items");
            return val;
          }
        }
      throw new InvalidOperationException("no matching items");
    }
