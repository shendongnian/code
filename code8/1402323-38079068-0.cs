    public static class EnumerableEx
    {
        public static IEnumerable<Tuple<T, T>> WithNext<T>(this IEnumerable<T> items)
        {
            var e = items.GetEnumerator();
            bool r = e.MoveNext();
            if (!r)
                yield break;
            do
            {
                T last = e.Current;
                var item = (r = e.MoveNext()) ? e.Current : default(T);
                yield return Tuple.Create(last, item);
            } while (r);
        }
    }
