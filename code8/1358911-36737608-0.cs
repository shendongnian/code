    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var defaultIndex = "zzz";
    	
    	var connectionSettings = new ConnectionSettings(pool)
    			.DefaultIndex(defaultIndex)
    			.MapDefaultTypeNames(m => m.Add(typeof(Class1), "omg"))
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
    
    	if (client.IndexExists(defaultIndex).Exists)
    	{
    		client.DeleteIndex(defaultIndex);
    	}
    
    	client.CreateIndex(defaultIndex);
    
    	client.Index(new Class1
    	{
    		Id = 1,
    		Answer = "The quick brown fox jumps over the lazy dog"
    	}, i => i.Refresh());
    
    	var searchResponse = client.Search<Class1>(s => s
    		.Query(q => q
    			.MatchPhrase(mp => mp
    				.Field(f => f.Answer)
    				.Query("brown dog")
    				.Slop(5)
    			)
    		)
    	);
    
    	Console.WriteLine(searchResponse.MaxScore);
    }
        
    public class Class1
    {
    	public int Id { get; set; }
    	public string Answer { get; set;}
    }
