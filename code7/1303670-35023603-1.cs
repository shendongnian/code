    using SysSurge.Slazure.MongoDB.Linq;
    using SysSurge.Slazure.Core;
    using SysSurge.Slazure.Core.Linq.QueryParser;
    
    public void EnumProperties()
    {
    	// Get a reference to the collection
    	dynamic storage = new QueryableStorage<DynDocument>("mongodb://user:pass@example.org/MongoDBExample");
    	QueryableCollection<DynDocument> collection = storage.TestCustomers;
    
    	// Build collection query
    	var queryResult = collection.Where("SignedUpForNewsletter = true and Age < 22");
    
    	foreach (DynDocument document in queryResult)
    	{
    		foreach (KeyValuePair<string, IDynProperty> keyValuePair in document)
    		{
    			Console.WriteLine(keyValuePair.Key);
    		}
    	}
    }
