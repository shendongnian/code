    public static IEnumerable<T1> FindSubsequence<T1, T2>(
        this IList<T1> first,
        IList<T2> second,
        Func<T1, T2, bool> matchPredicate)
    {
        for (int i = 0; i < first.Count - 1; i++)
        {
            var subsequence = first.Skip(i).Take(second.Count);
            if (subsequence.Zip(second, matchPredicate).All(x => x))
                return subsequence;
        }
        return Enumerable.Empty<T1>();
    }
