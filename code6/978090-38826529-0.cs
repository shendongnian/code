    public static async Task AddOrUpdateAsync<TDocument>(this IMongoIndexManager<TDocument> indexes, CreateIndexOptions options, IndexKeysDefinition<TDocument> keys = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                if (options == null)
                {
                    throw new ArgumentNullException(nameof(options));
                }
                if (keys == null)
                {
                    keys = Builders<TDocument>.IndexKeys.Ascending(options.Name);
                }
                try
                {
                    await indexes.CreateOneAsync(keys, options, cancellationToken).ConfigureAwait(false);
                }
                catch (MongoCommandException e)
                {
                    await indexes.DropOneAsync(options.Name, cancellationToken).ConfigureAwait(false);
                    await AddOrUpdateAsync(indexes, options, keys, cancellationToken).ConfigureAwait(false);
                }
            }
