    public static class EnumerableExtensions
    {
        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection ?? Enumerable.Empty<T>();
        }
      
        public static IEnumerable<T> Recurse<T>(
            this IEnumerable<T> collection, 
            Func<T, IEnumerable<T>> childrenSelector)
        {
            return collection.SelectMany(i => i.Recurse(childrenSelector));
        }
        public static IEnumerable<T> Recurse<T>(
            this T parent, 
            Func<T, IEnumerable<T>> childrenSelector)
        {
            yield return parent;
            var children = childrenSelector(parent).OrEmpty();
            foreach (var descendant in children.Recurse(childExpr))
            {
                yield return descendant;
            }
        }
    }
