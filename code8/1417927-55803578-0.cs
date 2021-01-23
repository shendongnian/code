    internal class EagerEvaluator<T>
    {
        private readonly T _first;
        private readonly IEnumerator<T> _enumerator;
        private readonly bool _hasFirst;
        
        public EagerEvaluator(IEnumerable<T> enumerable)
        {
            _enumerator = enumerable.GetEnumerator();
            if (_enumerator.MoveNext())
            {
                _hasFirst = true;
                _first = _enumerator.Current;                
            }
        }
    
        public IEnumerable<T> ToEnumerable()
        {
            if (_hasFirst)
            {
                yield return _first;
                
                while (_enumerator.MoveNext())
                {
                    yield return _enumerator.Current;                
                }
            }
        }
    }
