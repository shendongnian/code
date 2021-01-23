    // I am assuming that Credential overrides Equals. Otherwise
    // the lookup will only work if the same instance of Credential 
    // is supplied for different concurrent calls. This is not a limitation
    // of this code per se. *Any* method which relies on being able to
    // compare Credential instances for equality will run into this.
    private readonly Dictionary<Credential, Lazy<Data>> Cache
        = new Dictionary<Credential, Lazy<Data>>();
    public Data GetData(Credential credential)
    {
        Lazy<Data> lazy;
        lock (Cache)
        {
            if (!Cache.TryGetValue(credential, out lazy))
            {
                lazy = new Lazy<Data>(() => GetDataInternal(credential));
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
