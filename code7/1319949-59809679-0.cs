cs
public ValueTask<T> GetAsync<T>(IQueryable<T> source, object[] keyValues, CancellationToken cancellationToken = default)
    where T : class
{
    if (source == null)
    {
        throw new ArgumentNullException(nameof(source));
    }
    if (keyValues == default)
    {
        throw new ArgumentNullException(nameof(keyValues));
    }
    if (keyValues.Length != 1)
    {
        throw new ArgumentException("Key values must contain exactly one key value", nameof(keyValues));
    }
    var type = typeof(T);
    var classMap = BsonClassMap.LookupClassMap(type);
    if (classMap == default)
    {
        throw new InvalidOperationException($"Class map not found for '{type.Name}'");
    }
    var id = classMap.IdMemberMap;
    if (id == default)
    {
        throw new InvalidOperationException($"Id member not found for '{type.Name}'");
    }
    var filter = Builders<T>.Filter.Eq(id.ElementName, keyValues[0]);
    var collection = Database.GetCollection<T>(type.Name);
    async ValueTask<T> GetAsync()
    {
        var cursor = await collection.FindAsync<T>(filter, default, cancellationToken).ConfigureAwait(false);
        return await cursor.SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);
    }
    return GetAsync();
}
