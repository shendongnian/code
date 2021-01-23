    public static class Extensions
    {
    	public static Task ForEachAsync<T>(this IEnumerable<T> source, int dop, Func<T, Task> body)
    	{ 
    		return Task.WhenAll( 
    			from partition in Partitioner.Create(source).GetPartitions(dop) 
    			select Task.Run(async delegate { 
    				using (partition) 
    					while (partition.MoveNext()) 
    						await body(partition.Current); 
    			})); 
    	}
    }
    
    void Main()
    {
    	var myClientProxy = new ClientProxy(); 
    	var responses = new List<Response>();
    	
        // Max 10 concurrent requests
    	Requests.ForEachAsync<Request>(10, async (r) =>
	    {
		    var response = await client.GetResponsesAsync( localTransaction.Request );
		    responses.Add(response);
  	    }).Wait();    	
    }
