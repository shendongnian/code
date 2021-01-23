    public class RewindableRingBuffer<T>
    {
        private readonly T[] _values;
        private int _head;  // index of oldest value
        private int _count; // number of elements
        public RewindableRingBuffer(int capacity)
        {
            _values = new T[capacity];
            _head = 0;
            _count = 0;
        }
        public int Count { get { return _count; } }
        public T this[int index]
        {
            get 
            {
                if ((uint)index >= (uint)_count)
                    throw new IndexOutOfRangeException("index");
                return _values[(_head + index) % _values.Length];
            }
        }
        public void Add(T value)
        {
            var tail = (_head + _count) % _values.Length;
            if (_count < _values.Length)
                _count++; // was not yet filled to capacity.
            else
                _head = (_head + 1) % _values.Length; // remove oldest.
            _values[tail] = value;
        }
        public T Min 
        {
            get { return Enumerate().Min(); }
        }
        public T Max
        {
            get { return Enumerate().Max(); }
        }
        public IEnumerable<T> Enumerate()
        {
            // enumerates oldest to newest.
            for (var i = 0; i < _count; i++)
                yield return _values[(_head + i) % _values.Length];
        }
        public void RewindBy(int num)
        {
            // Goes back in history, by removing the 'num'
            // most recent values.
            _count = Math.Max(0, _count - num);
        }
    }
