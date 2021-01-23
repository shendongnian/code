    public Data GetData(Credentials credential)
    {
       var data = new Lazy<Data>(() => GetCurrentInternal(credential));
       var lazydata  = (Lazy<Data>)MemoryCache.Default.AddOrGetExisting(
                       (credential ?? EmptyMetadataCredentials).ToString(),
                        data,
                        DateTime.Now.AddMinutes(5));
        return (lazydata ?? data).Value;
    }
