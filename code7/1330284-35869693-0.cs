    ObjectCache cache = MemoryCache.Default;
    DataContractSerializer serializer = cache["Serializer"] as DataContractSerializer;
    if (serializer == null)
    {
        serializer = new DataContractSerializer(typeof(BackgroundJobInfo),
            null,
            int.MaxValue,
            true,
            true,
            new MongoDbSurrogate()); // MongoDbSurrogate : IDataContractSurrogate
        // Cache the serializer with an policy that never expires the cache item.
        CacheItemPolicy policy = new CacheItemPolicy();
        cache.Set("Serializer", serializer, policy.AbsoluteExpiration);
    }
    serializer.WriteObject(xmlWriter, info);
