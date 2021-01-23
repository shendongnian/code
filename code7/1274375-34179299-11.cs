    private readonly Dictionary<Credential, Lazy<Data>> Cache
        = new Dictionary<Credential, Lazy<Data>>();
    public Data GetData(Credential credential)
    {
        if (credential == null)
        {
            // Pass-through, no caching.
            return GetDataInternal(null);
        }
        Lazy<Data> lazy;
        lock (Cache)
        {
            if (!Cache.TryGetValue(credential, out lazy))
            {
                // ExecutionAndPublication is the default LazyThreadSafetyMode, but I 
                // wanted to spell it out to drive the point home: this Lazy instance 
                // will only allow a single call to GetDataInternal, even if multiple
                // threads query its Value property simultaneously.
                lazy = new Lazy<Data>(
                    () => GetDataInternal(credential),
                    LazyThreadSafetyMode.ExecutionAndPublication
                );
                Cache.Add(credential, lazy);
            }
        }
        // We have released the lock on Cache to allow other threads
        // (with potentially *different* credentials) to access the
        // cache and proceed with their own work in parallel with us.
        Data data;
        try
        {
            // Wait for the GetDataInternal call to complete.
            data = lazy.Value;
        }
        finally
        {
            // At this point the call to GetDataInternal has completed and Data is ready.
            // We will invalidate the cache entry if another thread hasn't done so already.
            lock (Cache)
            {
                // The lock is required to ensure the atomicity of our "fetch + compare + remove" operation.
                // *ANY* thread is allowed to invalidate the cached value, not just the thread that created it.
                // This ensures that the cache entry is cleaned up sooner rather than later.
                // The equality check on the Lazy<Data> instance ensures that the cache entry
                // is not cleaned up too soon, and prevents the following race:
                // (assume all operations use identical credentials)
                // - Thread A creates and stores a Lazy<Data> instance in the cache.
                // - Thread B fetches the Lazy<Data> instance created by Thread A.
                // - Threads A and B access Lazy<Data>.Value simultaneously.
                // - Thread B wins the race and enters the second (this) protected
                //   region and invalidates the cache entry created by Thread A.
                // - Thread C creates and stores a *NEW* Lazy<Data> instance in the cache.
                // - Thread C accesses its Lazy<Data>.Value.
                // - Thread A finally gets to invalidate the cache, and OOPS, Thread C's cache
                //   entry is invalidated before the call to Lazy<Data>.Value has completed.
                // With the equality check in place, Thread A will *not*
                // invalidate the cache entry created by another thread.
                Lazy<Data> currentLazy;
                if (Cache.TryGetValue(credential, out currentLazy) && lazy == currentLazy)
                {
                    // Need to invalidate.
                    Cache.Remove(credential);
                }
            }
        }
        return data;
    }
