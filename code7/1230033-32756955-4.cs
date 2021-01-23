    public class ListSlice<T> : IReadOnlyList<T>
    {
        private readonly List<T> _list;
        private readonly int _start;
        private readonly int _exclusiveEnd;
        public ListSlice(List<T> list, int start, int exclusiveEnd)
        {
            _list = list;
            _start = start;
            _exclusiveEnd = exclusiveEnd;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _start; i <= _exclusiveEnd; ++i)
                yield return _list[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int Count
        {
            get { return _exclusiveEnd - _start; }
        }
        public T this[int index]
        {
            get { return _list[index+_start]; }
            set { _list[index+_start] = value; }
        }
    }
