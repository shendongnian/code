    public static partial class EnumerableExtensions { 
      // Simplest; IEquatable<T> for advanced version
      public static IEnumerable<T> Continuous<T>(this IEnumerable<T> source) {
        if (null == source)
          throw new ArgumentNullException("source");  
    
        T lastItem = default(T);
        Boolean first = true;
    
        foreach (var item in source) {
          if (first) {
            lastItem = item;
            first = false;
          }
          else if (Object.Equals(item, lastItem)) 
            yield return item;
          else
            lastItem = item; 
        }
      }  
    }
