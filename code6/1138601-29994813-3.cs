    static bool SomeButNotAll<TSource>(this IEnumerable<TSource> source,
                                       Func<TSource, bool> predicate)
    {
       using(var iter=source.GetEnumerator())
       {
         if (iter.MoveNext())
         {
           bool initialValue=predicate(iter.Current);
           while (iter.MoveNext())
             if (predicate(iter.Current)!=initialValue)
               return true;
         }
       }     
       return false; /* All */
    }
