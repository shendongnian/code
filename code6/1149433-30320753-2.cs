    class Reeks : IEnumerable<int>, IEnumerator<int>
    {
        private int current;
        private int idx = -1;
        public IEnumerator<int> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        public void Dispose()
        {
            Reset();
        }
        public bool MoveNext()
        {
            if (idx == -1)
            {
                idx = 0;
                current = 1;
            }
            else
            {
                current = current * 2;
            }
            return true;
        }
        public void Reset()
        {
            idx = -1;
        }
        public int Current
        {
            get
            {
                if (idx == -1)
                    throw new InvalidOperationException("Enumeration has not started. Call MoveNext");
                return current;
            }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
