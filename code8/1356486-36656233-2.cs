    class TupleComparer<T> : IEqualityComparer<Tuple<T, T>>
    {
        public bool Equals(Tuple<T, T> x, Tuple<T, T> y)
        {
            return object.Equals(x.Item1, y.Item1) && object.Equals(x.Item2, y.Item2) ||
                   object.Equals(x.Item1, y.Item2) && object.Equals(x.Item2, y.Item1);
        }
        public int GetHashCode(Tuple<T, T> obj)
        {
            return obj.Item1.GetHashCode() + obj.Item2.GetHashCode();
        }
    }
