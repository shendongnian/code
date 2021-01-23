    static bool SomeButNotAll<TSource>(this IQueryable<TSource> source,
                                       Expression<Func<TSource, bool>> predicate)
    {
       var iter=source.GetEnumerator();
       if (!iter.MoveNext())
         return false;  /* Not "Some" */
       bool init=predicate(iter.Current);
       while (iter.MoveNext())
         if (predicate(iter.Current)!=init)
           return true;
       
       return false; /* All */
    }
