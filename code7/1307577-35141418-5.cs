    public static IEnumerable<TOutput> UniquifyNames<TSource, TOutput>(
       this IEnumerable<TSource> source,
       Func<TSource, string> nameSelector,
       Func<TSource, string, TOutput> resultProjection
    ) {
       HashSet<string> existingNames = new HashSet<string>();
       var items = source
          .Select(item => {
             string name = nameSelector(item);
             return resultProjection(
                item,
                Enumerable.Range(1, int.MaxValue)
                   .Select(i => {
                      string suffix = i == 1
                         ? ""
                         : (name.EndsWithDigit() ? "-" : "") + i.ToString();
                      return $@"{name}{suffix}";
                   })
                   .First(candidateName => existingNames.Add(candidateName))
             );
          });
        foreach(TOutput item in items)
        {
            yield return item;
        }
    }
