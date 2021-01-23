    using(var i1 = seq1.GetEnumerator())
    using(var i2 = seq2.GetEnumerator())
    using(var i3 = seq3.GetEnumerator())
    {
        while(i1.MoveNext() && i2.MoveNext() && i3.MoveNext())
        {
            var tuple = Tuple.Create(i1.Current, i2.Current, i3.Current);
            // ...
        }
    }
