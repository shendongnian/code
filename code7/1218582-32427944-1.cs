    public List<Candidate> GetCandidateById(int candidateId)
    {
        var client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);
        Database database = client.CreateDatabaseQuery().Where(db => db.Id == DatabaseName).AsEnumerable().FirstOrDefault();
        DocumentCollection documentCollection = client.CreateDocumentCollectionQuery(database.CollectionsLink).Where(db => db.Id == DocumentCollectionName).AsEnumerable().FirstOrDefault();
     
        return client.CreateDocumentQuery<Candidate>(documentCollection.DocumentsLink).Where(m => m.CandidateId == candidateId).Select(m => m).ToList();
    }
