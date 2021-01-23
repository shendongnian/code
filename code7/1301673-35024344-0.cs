    using SysSurge.Slazure.AzureDocumentDB.Linq;
    using SysSurge.Slazure.Core;
    using SysSurge.Slazure.Core.Linq.QueryParser;
    
    public void ShowYoungCustomerWithNewsletterEmails()
    {
    	// Get a reference to the collection
    	dynamic storage = new QueryableStorage<DynDocument>("URL=https://contoso.documents.azure.com:443/;DBID=DDBExample;TOKEN=VZ+qKPAkl9TtX==");
    	QueryableCollection<DynDocument> collection = storage.TestCustomers;
    
    	// Build collection query
    	var queryResult = collection.Where("SignedUpForNewsletter = true and Age < 22");
    
    	foreach (var document in queryResult)
    	{
    		Console.WriteLine(document.email);
    	}
    }
