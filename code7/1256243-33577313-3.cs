    // Thread-safe
    public class Memoized<T>
    {
        Func<T> _compute;
        volatile bool _cached;
        volatile StrongBox<T> _cachedResult;  // Need reference type
        object _cacheSyncRoot = new object();
        public Memoized(Func<T> compute)
        {
            _compute = compute;
        }
        public T Value {
            get {
                if (_cached)    // Fast path
                    return _cachedResult.Value;
                lock (_cacheSyncRoot)
                {
                    if (!_cached)
                    {
                        _cachedResult = new StrongBox<T>(_compute());
                        _cached = true;
                    }
                }
                return _cachedResult.Value;
            }
        }
        public void Invalidate()
        {
            lock (_cacheSyncRoot)
                _cached = false;
        }
    }
