    public static IEnumerable<Tuple<T1, T2, T3, T4>> ZipTuple<T1, T2, T3, T4>(
        this IEnumerable<T1> source1,
        IEnumerable<T2> source2,
        IEnumerable<T3> source3,
        IEnumerable<T4> source4)
    {
        // TODO: Extract a separate public method from the implementation
        // method and perform eager validation for nullity
        using (var iterator1 = source1.GetEnumerator())
        using (var iterator2 = source2.GetEnumerator())
        using (var iterator3 = source3.GetEnumerator())
        using (var iterator4 = source4.GetEnumerator())
        {
            while (iterator1.MoveNext() && iterator2.MoveNext() &&
                   iterator3.MoveNext() && iterator4.MoveNext())
            {
                yield return Tuple.Create(
                    iterator1.Current,
                    iterator2.Current,
                    iterator3.Current,
                    iterator4.Current);
            }
        }
    }
