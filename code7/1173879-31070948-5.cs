    var termVectorResponse = client.TermVector<MyDocument>(t => t
    	.Document(myDocument)
        //.Id(1) //you can specify document by id as well
    	.TermStatistics()
    	.Fields(f => f.Description));
    foreach (var item in termVectorResponse.TermVectors)
    {
    	Console.WriteLine("Field: {0}", item.Key);
    
    	foreach (var term in item.Value.Terms)
    	{
    		Console.WriteLine("{0}: {1}", term.Key, term.Value.TermFrequency);
    	}
    }
