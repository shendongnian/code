    ObjectCache cache = MemoryCache.Default;
    DataContractSerializer serializer = cache["MonogoSerialzier"] as DataContractSerializer;
    if (serializer == null)
    {
        serializer = new DataContractSerializer(typeof(BackgroundJobInfo),
            null,
            int.MaxValue,
            true,
            true,
            new MongoDbSurrogate()); // MongoDbSurrogate : IDataContractSurrogate
        // Cache the serializer with an policy that never expires the cache item.
        cache.Set("MonogoSerialzier", serializer, new CacheItemPolicy().AbsoluteExpiration);
    }
    serializer.WriteObject(xmlWriter, info);
