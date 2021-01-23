    public class TripleCollection<T> : IEnumerable<Tuple<T, T, T>>
    {
        readonly List<Tuple<T, T, T>> list = new List<Tuple<T, T, T>>();
        public void Add(T first, T second, T third)
        {
            list.Add(Tuple.Create(first, second, third));
        }
        public IEnumerator<Tuple<T, T, T>> GetEnumerator()
        {
            return list.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
