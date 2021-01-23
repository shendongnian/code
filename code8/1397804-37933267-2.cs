    class EnumeratorWrap: Iterator
    {
        private IEnumerator _iter;
        private bool _hasNext;
        private object _next;
    
        public EnumeratorWrap(IEnumerator iter)
        {
            _iter = iter;
            Next();
        }
    
        public bool HasNext() 
        {
            return _hasNext;
        }
    
        public object Next()
        {
            object current = _next;
            _hasNext = _iter.MoveNext();
            _next = _hasNext ? _iter.Current : null;
            return current;
        }
    }
