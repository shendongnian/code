    public static class Iterate
    {
        public static IEnumerable<Tuple<T1, T2, T3>> Over<T1, T2, T3>(IEnumerable<T1> t1s, IEnumerable<T2> t2s, IEnumerable<T3> t3s)
        {
            using(var it1s = t1s.GetEnumerator())
            using(var it2s = t2s.GetEnumerator())
            using(var it3s = t3s.GetEnumerator())
            {
                while(it1s.MoveNext() && it2s.MoveNext() && it3s.MoveNext())
                    yield return Tuple.Create(it1s.Current, it2s.Current, it3s.Current);
            }
        }
    }
