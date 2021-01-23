    public static IEnumerable<T> OrderAfterFirst<T, TKey>(this IEnumerable<T> src,
                                                          Func<T, TKey> keySelector)
    {
        // Ensure you don't throw or return null or whatever if the collection is empty
        foreach (var first in src.Take(1))
        {
            yield return first;
        }
        // Return the rest of the elements ordered
        foreach (var x in src.Skip(1).OrderBy(keySelector))
        {
            yield return x;
        }
    }
