    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var defaultIndex = "pets";
    	var connectionSettings = new ConnectionSettings(pool)
    			.DefaultIndex(defaultIndex);
    				
    	var client = new ElasticClient(connectionSettings);
    	
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
            
        client.CreateIndex(defaultIndex, ci => ci
            .Mappings(m => m
                .Map<Dog>(d => d.AutoMap())
                .Map<Cat>(c => c.AutoMap())
            )
        );
    
        var dogs = Enumerable.Range(1, 100).Select(i => new Dog
        {
            Name = $"Dog {i}"
        });
        
        client.IndexMany(dogs);
    
        var cats = Enumerable.Range(1, 100).Select(i => new Cat
        {
            Name = $"Cat {i}",
            Enabled = i % 2 == 0 ? false : true
        });
    
        client.IndexMany(cats);
        client.Refresh(defaultIndex);
    
        client.Search<object>(s => s
            .Size(100)
            .SearchType(SearchType.Count)
            .Type(Types.Type(typeof(Dog), typeof(Cat)))
            .Query(q => 
                (+q.Term("_type", "cat") && +q.Term("enabled", true)) ||
                +q.Term("_type", "dog")
            )
        );
    }
