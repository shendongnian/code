    static IEnumerable<C> Deduplicate(this IEnumerable<C> items) {
     C last = null;
     foreach (var item in items) {
      if (last != null && last.A == item.A && last.B == item.B) {
       //duplicate, handle as you like
      }
    
      last = item;
      yield return item;
    }
