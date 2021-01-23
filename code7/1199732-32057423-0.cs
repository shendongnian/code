    // PagingInfo is Required. 
    var request = new RetrieveDuplicatesRequest
    {
        BusinessEntity = new Account { Name = "Microsoft" }.ToEntity<Entity>(),
        MatchingEntityName = Account.EntityLogicalName,
        PagingInfo = new PagingInfo() { PageNumber = 1, Count = 50 }
    };
    Console.WriteLine("Retrieving duplicates");
    var response =(RetrieveDuplicatesResponse)_serviceProxy.Execute(request);
    for (int i = 0; i < response.DuplicateCollection.Entities.Count; i++)
    {
        var crmAccount = response.DuplicateCollection.Entities[i].ToEntity<Account>();
        Console.WriteLine(crmAccount.Name + ", " + crmAccount.AccountId.Value.ToString()); 
    }
