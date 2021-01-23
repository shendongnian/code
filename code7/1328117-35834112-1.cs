    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var connectionSettings = new ConnectionSettings(pool)
    		// Disabling direct streaming and logging out requests and responses
            // is useful during development, but may not want to do this
            // in production as it has performance implications.
            // Used here to write out requests and responses.
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
    			})
    			.DefaultIndex("users");
    
    	var client = new ElasticClient(connectionSettings);
    
    	var ui = new UserInfo { UserName = "Andy", Name = "", UserNr = 1 };
    
    	if (!client.IndexExists("users").Exists)
    	{
    		client.CreateIndex("users");
    	}
    	
        // can use index
    	client.Index(ui, descriptor => descriptor.Refresh());
    
    	var pageSize = 10;
    	var currentPage = 1;
    	var name = "gujjghjhgj";
    
    	var searchResponse = client.Search<UserInfo>(s => s
    		.Index("users")
    		.Query(q => q
    			.Match(m => m
    				// specify the field 
    				.Field(f => f.UserName)
    				.Query(name)				
    			)
    		)
    		.Size(pageSize)
    		.From((currentPage - 1) * pageSize)
    	);
    
    	var total = searchResponse.Total; 
    	var docs = searchResponse.Documents.ToList();
    }
    
    [Serializable, ElasticsearchType(IdProperty = "UserNr")]
    public class UserInfo
    {
    	public string UserName { get; set; }
    	public string Name { get; set; }
    	public string Avatar { get; set; }
    	public int UserNr { get; set; }
    }
