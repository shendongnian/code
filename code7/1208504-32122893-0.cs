    public static EnumerableExtensions {
      public static IEnumerable<TResult> Merge<TFirst, TSecond, TResult>(
        this IEnumerable<TFirst> first,
        IEnumerable<TSecond> second,
        Func<TFirst, TSecond, TResult> map) {
    
          if (Object.ReferenceEquals(null, first))
            throw new ArgumentNullException("first");
          else if (Object.ReferenceEquals(null, second))
            throw new ArgumentNullException("second");
          else if (Object.ReferenceEquals(null, map))
            throw new ArgumentNullException("map");
    
          using (var enFirst = first.GetEnumerator()) {
            using (var enSecond = second.GetEnumerator()) {
              while (enFirst.MoveNext())
                if (enSecond.MoveNext())
                  yield return map(enFirst.Current, enSecond.Current);
                else
                  yield return map(enFirst.Current, default(TSecond));
    
              while (enSecond.MoveNext())
                yield return map(default(TFirst), enSecond.Current);
            }
          }
        }
      }
    }
    
    ...
    
    var result = File
      .ReadLines(@"C:\First.txt")
      .Merge(File.ReadLines(@"C:\Second.txt"), 
             (line1, line2) => line1 + line2);
    
    File.WriteAllLines(@"C:\CombinedFile.txt", result);
