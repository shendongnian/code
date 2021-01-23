    public class VolatileStrongBox<T>
        where T : struct
    {
        public volatile T Value;
    }
    volatile bool _cached;
    VolatileStrongBox<int> _cachedResult;  // Can just use plain volatile for reference types
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
                _cachedResult.Value = /* Result of expensive computation. */;
                _cached = true;
            }
        }
        return _cachedResult.Value;
    }
    // Thread-safe
    public void InvalidateCache()
    {
        _cached = false;
    }
