    public static IEnumerable<T> Zip<T1,T2,T3> (this IEnumerable<T1> e1, IEnumerable<T2> e2, IEnumerable<T3> e3) 
    {
        var i1 = e1.GetEnumerator();
        var i2 = e2.GetEnumerator();
        var i3 = e3.GetEnumerator();
        // warning: this implementation does not fail if the enumerable do not
        // have the same sizes, it stops when the shortest one is enumerated
        while (i1.MoveNext() && i2.MoveNext() && i3.MoveNext()) {
            yield return Tuple.Create(i1.Current,i2.Current,i3.Current);
        }
    }
