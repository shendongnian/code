    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var defaultIndex = "logstash-" + DateTime.UtcNow.ToString("yyyy-MM-dd");
    	var connectionSettings = new ConnectionSettings(pool)
    			.DefaultIndex(defaultIndex)
                .InferMappingFor<LogResponse>(m => m
                    .TypeName("log")
                );
    				
    	var client = new ElasticClient(connectionSettings);
    
        // delete the index if it exists. Useful for demo purposes
        if (client.IndexExists(defaultIndex).Exists)
        {
            client.DeleteIndex(defaultIndex);
        }
    
        // use the lowlevel client to send the exact json as 
        // it would be sent from the source
        var createResponse = client.LowLevel.Index<string>(
            defaultIndex, 
            "log",
            @"{
                ""@timestamp"": ""2016-08-17T08:57:37.3487446+02:00"",
                ""level"": ""Information"",
                ""messageTemplate"": ""User login {UserId}"",
                ""message"": ""User login .."",
                ""fields"": {
                  ""UserId"": ""29a35806-15d2-4eed-a3bf-707760e426b8"",
                  ""ProcessId"": 15568,
                  ""ThreadId"": 14,
                  ""MachineName"": ""..."",
                  ""EnvironmentUserName"": ""..."",
                  ""HttpRequestId"": ""..."",
                  ""HttpRequestClientHostIP"": ""::1"",
                  ""HttpRequestType"": ""POST"",
                  ""Version"": ""1.0.0.0""
                }
            }");
    
        if (!createResponse.SuccessOrKnownError)
        {
            Console.WriteLine("Error indexing document");
        }
        
        // Refresh the index after indexing. Useful for demo purposes.
        client.Refresh(defaultIndex);
    
        var searchResponse = client.Search<LogResponse>(s => s
            .AllTypes()
            .Size(50)
            .Query(q => q
                .MatchAll()
            )
        );
    
        foreach (var document in searchResponse.Documents)
        {
            Console.WriteLine(document.Timestamp);
        }
    }
    
    public class LogResponse
    {
        public string Message { get; set; }
        [Date(Name = "@timestamp")]
        public DateTime Timestamp { get; set; }
        public LogResponseFields Fields { get; set; }
    
        public class LogResponseFields
        {
            public Guid UserId { get; set; }
        }
    }
