    public delegate T EntityResolver<T>(
        string partitionKey,
        string rowKey,
        DateTimeOffset timestamp,
        IDictionary<string, EntityProperty> properties,
        string etag
    );
