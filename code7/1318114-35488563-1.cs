    var collLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
    var querySpec = new SqlQuerySpec { <querytext> };
    
    var itr = client.CreateDocumentQuery(collLink, querySpec).AsDocumentQuery();
    var response = itr.ExecuteNextAsync<Document>().Result;
    
    foreach (var doc in response.AsEnumerable())
    {
        // ...
    }
