    static class EnumerableExtensions {
    
      public static IEnumerable<IEnumerable<T>> GroupOnChange<T>(
        this IEnumerable<T> source,
        Func<T, T, Boolean> changePredicate
      ) {
        if (source == null)
          throw new ArgumentNullException("source");
        if (changePredicate == null)
          throw new ArgumentNullException("changePredicate");
        using (var enumerator = source.GetEnumerator()) {
          if (!enumerator.MoveNext())
            yield break;
          var firstValue = enumerator.Current;
          var currentGroup = new List<T>();
          currentGroup.Add(firstValue);
          while (enumerator.MoveNext()) {
            var secondValue = enumerator.Current;
            var change = changePredicate(firstValue, secondValue);
            if (change) {
              yield return currentGroup;
              currentGroup = new List<T>();
            }
            currentGroup.Add(secondValue);
            firstValue = secondValue;
          }
          yield return currentGroup;
        }
      }
    
    }
