    private readonly Dictionary<Credential, Lazy<Data>> Cache
        = new Dictionary<Credential, Lazy<Data>>();
    public Data GetData(Credential credential)
    {
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
        // Wait for the GetDataInternal call to complete.
        Data data = lazy.Value;
        // At this point the call to GetDataInternal has completed and Data is ready.
        // We will invalidate the cache entry if another thread hasn't done so already.
        lock (Cache)
        {
            Lazy<Data> currentLazy;
            if (Cache.TryGetValue(credential, out currentLazy) && lazy == currentLazy)
            {
                // Need to invalidate.
                Cache.Remove(credential);
            }
        }
        return data;
    }
