    public IEnumerable<List<int>> Parse(IEnumerable<int> source) {
       if (source == null) {
          throw new ArgumentNullException(nameof (source));
       }
       var enumerator = source.GetEnumerator();
       if (!enumerator.MoveNext()) {
          return Enumerable.Empty<List<int>>();
       }
       if (enumerator.Current != 0) {
          throw new ArgumentException(nameof (source), "Source enumerable must begin with a 0.");
       }
       return ParseImpl(enumerator);
    }
    
    private IEnumerable<List<int>> ParseImpl(IEnumerator<int> enumerator) {
       var list = new List<int>();
       while (enumerator.MoveNext()) {
          if (enumerator.Current == 0) {
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
