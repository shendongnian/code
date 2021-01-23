    [ThreadStatic]
    public static DataContractSerializer serializer = new DataContractSerializer(typeof(BackgroundJobInfo),
        null,
        int.MaxValue,
        true,
        true,
        new MongoDbSurrogate());
