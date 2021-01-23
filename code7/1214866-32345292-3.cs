	public IObservable<ResourceResponse<Document>[]> SaveCategories(double requestCharge, Category[] categories)
	{
		var requestDelay = TimeSpan.FromSeconds(60.0 / (collectionOptions.RequestUnits / requestCharge));
	
		var client = new DocumentClient(endpoint, authorizationKey,
			new ConnectionPolicy
			{
				ConnectionMode = documentDbOptions.ConnectionMode,
				ConnectionProtocol = documentDbOptions.ConnectionProtocol
			});
	
		return
			Observable.Timer(requestDelay)
				.Zip(documents, (delay, doc) => doc)
				.SelectMany(doc => Observable.FromAsync(() => client.PutDocumentToDb(collectionOptions.CollectionLink, doc.SearchIndex, doc)))
				.ToArray();
	}
