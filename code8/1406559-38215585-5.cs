    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var defaultIndex = "default-index";
    	var connectionSettings = new ConnectionSettings(pool, new InMemoryConnection())
    			.DefaultIndex(defaultIndex)
    			.PrettyJson()
    			.DisableDirectStreaming()
    			.OnRequestCompleted(response =>
    				{
    					// log out the request
    					if (response.RequestBodyInBytes != null)
    					{
    						Console.WriteLine(
    							$"{response.HttpMethod} {response.Uri} \n" +
    							$"{Encoding.UTF8.GetString(response.RequestBodyInBytes)}");
    					}
    					else
    					{
    						Console.WriteLine($"{response.HttpMethod} {response.Uri}");
    					}
                        
                        Console.WriteLine();
    
    					// log out the response
    					if (response.ResponseBodyInBytes != null)
    					{
    						Console.WriteLine($"Status: {response.HttpStatusCode}\n" +
    								 $"{Encoding.UTF8.GetString(response.ResponseBodyInBytes)}\n" +
    								 $"{new string('-', 30)}\n");
    					}
    					else
    					{
    						Console.WriteLine($"Status: {response.HttpStatusCode}\n" +
    								 $"{new string('-', 30)}\n");
    					}
    				});
    				
    	var client = new ElasticClient(connectionSettings);
    	  
        int skipCount = 0;
        int takeSize = 100;
    
        var searchResults = client.Search<myPoco>(x => x
            .Query(q => q
            .Bool(b => b
            .Must(m =>
                m.Match(mt1 => mt1.Field(f1 => f1.status).Query("New")))))
            .Skip(skipCount)
            .Take(takeSize)
        );
    }
