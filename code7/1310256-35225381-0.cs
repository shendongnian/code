    internal class Extensions
    {
        public static IEnumerable<T> GetDuplicates<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            return source.GroupBy(keySelector)
                         .Where(group => group.Skip(1).Any())
                         .SelectMany(group => group);
        }
        public static bool ContainsDuplicates<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            return GetDuplicates(source, keySelector).Any();
        }
    }
