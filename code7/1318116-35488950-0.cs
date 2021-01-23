    public bool ExistsDocument(string id)
    {
    	var client = new DocumentClient(DatabaseUri, DatabaseKey);
    	var collectionUri = UriFactory.CreateDocumentCollectionUri("dbName", "collectioName");
        var query = client.CreateDocumentQuery<Microsoft.Azure.Documents.Document>(collectionUri, new FeedOptions() { MaxItemCount = 1 });
    	return query.Where(x => x.Id == id).Select(x=>x.Id).AsEnumerable().Any(); //using Linq
    }
