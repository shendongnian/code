    private class NamedItem<TSource> {
       public TSource Item { get; set; }
       public string Name { get; set; }
    }
    
    private static bool EndsWithADigit(this string value) =>
       !string.IsNullOrEmpty(value) && "0123456789".Contains(value[value.Length - 1]);
 
    private static string GetNumberedName(string name, int index) =>
       name + (index == 1 ? "" : name.EndsWithADigit() ? $"-{index}" : $"{index}");
       
    private static bool ConditionalSetName<T>(
       NamedItem<T> namedItem, string name, HashSet<string> hashset
    ) {
       bool isNew = hashset.Add(name);
       if (isNew) { namedItem.Name = name; }
       return !isNew;
    }
 
    public static IEnumerable<TOutput> UniquifyNames<TSource, TOutput>(
       this IEnumerable<TSource> source,
       Func<TSource, string> nameSelector,
       Func<TSource, string, TOutput> resultProjection
    ) {
       var seen = new HashSet<string>();
       var result = source.Select((item, seq) => new NamedItem<TSource>{
          Item = item, Name = nameSelector(item)
       }).ToList();
       var remaining = result;
       int i = 1;
       do {
          remaining = remaining.Where(namedItem =>
             ConditionalSetName(namedItem, GetNumberedName(namedItem.Name, i++), seen)
          ).ToList();
       } while (remaining.Any());
       return result.Select(namedItem => resultProjection(namedItem.Item, namedItem.Name));
    }
