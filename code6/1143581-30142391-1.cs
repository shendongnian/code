    var collection = new DocumentCollection { id = "myCollectionID" };
    
    collection.IndexingPolicy.IncludedPaths.Add(new IndexingPath
    {
        IndexType = IndexType.Range,
        Path = "/\"TimeStamp\"/\"Epoch\"/?",
        NumericPrecision = 7
    });
    collection.IndexingPolicy.ExcludedPaths.Add("/");
    
    this._client.CreateDocumentCollectionAsync(database.SelfLink, collection);
