    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var defaultIndex = "default-index";
    	var connectionSettings = new ConnectionSettings(pool)
    			.DefaultIndex(defaultIndex);
    
    	var client = new ElasticClient(connectionSettings);
    	
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
    
        client.CreateIndex(defaultIndex, c => c
            .Mappings(m => m
                .Map<Metadata>(mm => mm.AutoMap())
            )
        );
    
        var metadata = Enumerable.Range(1, 1000).Select(i =>
            new Metadata
            {
                Id = i,
                Timestamp = DateTime.UtcNow.Date.AddDays(-(i-1)),
                Type = i % 2 == 0? "metadata-type-2" : "metadata-type-1"
            });
        
        client.IndexMany(metadata);
        client.Refresh(defaultIndex);
    
        var Type = "metadata-type-1";
        var NumberOfItems = 5;
    
        var searchResponse = client.Search<Metadata>(s => s
            .Query(q => q
                .Term(f => f.Type, Type)
            )
            .Size(NumberOfItems)
            .Sort(sort => sort
                .Descending(f => f.Timestamp)
            )
        );
    }
    
    public class Metadata
    {
        public int Id { get; set;}
        
        public DateTime Timestamp { get; set;}
        
        [String(Index = FieldIndexOption.NotAnalyzed)]
        public string Type { get; set;}
    }
