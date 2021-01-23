    void Main()
    {
    	var defaultIndex = "default-index";
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	
    	var settings = new ConnectionSettings(pool, new InMemoryConnection())
    			 .DefaultIndex(defaultIndex)
    			 .MapDefaultTypeNames(m => m.Add(typeof(Class1), "omg"))
    			 .PrettyJson()
    			 .DisableDirectStreaming();
    
    	var client = new ElasticClient(settings);
    	
    	client.CreateIndex("new-index", c => c
    		.Mappings(ms => ms
    			.Map<Class1>(m => m
    				.Properties(ps => ps
    					.String(s => s
    						.Name(n => n.Ans)
    						.Analyzer("english")
    					)
    				)
    			)
    		)
    	);
    }
    
    public class Class1
    {
    	public string Ans { get; set;}
    }
