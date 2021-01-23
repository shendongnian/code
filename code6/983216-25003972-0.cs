    public static bool AreSame<T>(this IEnumerable<T> source,
        IEqualityComparer<T> comparer)
    {
        comparer = comparer ?? EqualityComparer<T>.Default;
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
                return true;
            var first = iterator.Current;
            while (iterator.MoveNext())
                if (!comparer.Equals(first, iterator.Current))
                    return false;
            return true;
        }
    }
