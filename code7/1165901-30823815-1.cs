    public class BigList<T> : IEnumerable<T>
    {
        private List<T[]> _storage = new List<T[]>();
    
        private const int _maxStorageArraySize = 1000;
    
        public ulong Capacity { get; private set; }
    
        public BigList(ulong capacity) 
        {
            _storage = new List<T[]>();
    
            Capacity = capacity;
    
            int arraysRequired = (int)Math.Ceiling((double)capacity / (double)_maxStorageArraySize);
            int lastArraySize = (int)(capacity % (ulong)_maxStorageArraySize);
    
            for (int i = 0; i < arraysRequired; i++)
                _storage.Add(new T[(i + 1) < arraysRequired ? _maxStorageArraySize : lastArraySize]);
        }
    
        public T this[ulong idx]
        {
            get
            {
                int arrayIdx = (int)(idx / (ulong)_maxStorageArraySize);
                int arrayOff = (int)(idx % (ulong)_maxStorageArraySize);
                return _storage[arrayIdx][arrayOff];
            }
            set
            {
                int arrayIdx = (int)(idx / (ulong)_maxStorageArraySize);
                int arrayOff = (int)(idx % (ulong)_maxStorageArraySize);
    
                _storage[arrayIdx][arrayOff] = value;
            }
        }
    
        public class BigListEnumerator : IEnumerator<T>
        {
            private BigList<T> _bigList;
            private ulong _idx;
    
            public BigListEnumerator(BigList<T> bigList)
            {
                _bigList = bigList;
            }
            public T Current
            {
                get { return _bigList[_idx]; }
            }
    
            public void Dispose()
            {
                _bigList = null;
            }
    
            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }
    
            public bool MoveNext()
            {
                return _idx++ < _bigList.Capacity;
            }
    
            public void Reset()
            {
                _idx = 0;
            }
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return new BigListEnumerator(this);
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new BigListEnumerator(this);
        }
    }
