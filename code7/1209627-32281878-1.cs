    var entities = new List<Entity>();
    // Add a bunch of entities to the list...
    foreach (List<Entity> chunkedEntities in entities.ChunksOf(1000))
    {
        var response = await _client.InvokeApiAsync<List<Entity>, bool>("batchinsert", chunkedEntities);
    }
