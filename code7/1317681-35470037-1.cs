    public static IEnumerable<List<int>> Parse(this IEnumerable<int> source, int splitValue = 0) {
       if (source == null) {
          throw new ArgumentNullException(nameof (source));
       }
       using (var enumerator = source.GetEnumerator()) {
          if (!enumerator.MoveNext()) {
             return Enumerable.Empty<List<int>>();
          }
          if (enumerator.Current != splitValue) {
             throw new ArgumentException(nameof (source), $"Source enumerable must begin with a {splitValue}.");
          }
          return ParseImpl(enumerator, splitValue);
       }
    }
    
    private static IEnumerable<List<int>> ParseImpl(IEnumerator<int> enumerator, int splitValue) {
       var list = new List<int>();
       while (enumerator.MoveNext()) {
          if (enumerator.Current == splitValue) {
             yield return list;
             list = new List<int>(); 
          }
          else {
             list.Add(enumerator.Current);
          }
       }
       if (list.Any()) {
          yield return list;
       }
    }
