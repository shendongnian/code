      public static IEnumerable<Tuple<T, T>> ToTuples<T>(this IEnumerable<T> objects)
      {
         IEnumerator<T> enumerator = objects.GetEnumerator();
         while (enumerator.MoveNext())
         {
            T object1 = enumerator.Current;
            if (enumerator.MoveNext())
            {
               yield return Tuple.Create(object1, enumerator.Current);
            }
         }
      }
