    var rangeDefault = new DocumentCollection { Id = "rangeCollection" };                                                              
    rangeDefault.IndexingPolicy.IncludedPaths.Add(
    new IndexingPath {
        IndexType = IndexType.Range, 
            Path = "/",
            NumericPrecision = 7 });
    rangeDefault = await client.CreateDocumentCollectionAsync(
     database.SelfLink, 
    rangeDefault);   
