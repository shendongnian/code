    var getIndexResponse = await _elasticClient.GetIndexAsync(indexName);
	IIndexState remote = getIndexResponse.Indices[indexName];
    // move the index definition out of here and use it to create the index as well
	IIndexState local = new CreateIndexDescriptor(indexName);
	// only care about mappings
	var areMappingsSynced = JToken.DeepEquals
	(
		JObject.Parse(_elasticClient.Serializer.SerializeToString(new { local.Mappings })),
		JObject.Parse(_elasticClient.Serializer.SerializeToString(new { remote.Mappings }))
	);
