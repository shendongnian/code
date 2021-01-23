    private readonly ConcurrentDictionary<Credential, Lazy<Data>> Cache
        = new ConcurrentDictionary<Credential, Lazy<Data>>();
    public Data GetData(Credential credential)
    {
        // This instance will be thrown away if a cached
        // value with our "credential" key already exists.
        Lazy<Data> newLazy = new Lazy<Data>(
            () => GetDataInternal(credential),
            LazyThreadSafetyMode.ExecutionAndPublication
        );
        Lazy<Data> lazy = Cache.GetOrAdd(credential, newLazy);
        bool added = ReferenceEquals(newLazy, lazy); // If true, we won the race.
        Data data;
        try
        {
            // Wait for the GetDataInternal call to complete.
            data = lazy.Value;
        }
        finally
        {
            // Only the thread which created the cache value
            // is allowed to remove it, to prevent races.
            if (added) {
                Cache.TryRemove(credential, out lazy);
            }
        }
        return data;
    }
