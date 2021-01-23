    public static class TupleExtensions
    {
        public static T[][] ToPairArray<T>(this IEnumerable<Tuple<T, T>> collection)
        {
            return collection == null ? null : collection.Select(t => new[] { t.Item1, t.Item2 }).ToArray();
        }
        public static void SetFromPairArray<T>(this ICollection<Tuple<T, T>> collection, T[][] array)
        {
            if (collection == null)
                throw new ArgumentNullException();
            collection.Clear();
            foreach (var pair in array)
            {
                if (pair.Length != 2)
                    throw new ArgumentException("Inner array did not have length 2");
                collection.Add(Tuple.Create(pair[0], pair[1]));
            }
        }
    }
