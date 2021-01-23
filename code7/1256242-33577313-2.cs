    volatile bool _cached;
    volatile StrongBox<int> _cachedResult;  // Can just use plain int here, but need StrongBox for general value-type case
    object _cacheSyncRoot = new object();
    // Thread-safe
    public int GetComputationResult()
    {
        if (_cached)    // Fast path
            return _cachedResult.Value;
        lock (_cacheSyncRoot)
        {
            if (!_cached)
            {
                // Do the expensive computation.
                _cachedResult = new StrongBox<int>(/* Result of computation */);
                _cached = true;
            }
        }
        return _cachedResult.Value;
    }
    // Thread-safe
    public void InvalidateCache()
    {
        lock (_cacheSyncRoot)
            _cached = false;
    }
