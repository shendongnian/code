    foreach (var jsonConverter in jsonConverters)
    {
        if (!CouchbaseClientExtensions
                 .JsonSerializerSettings
                 .Converters.Any(x => x.GetType() == jsonConverter.GetType()))
        {
            CouchbaseClientExtensions
                .JsonSerializerSettings
                .Converters.Add(jsonConverter);
        }
    }
