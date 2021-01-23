    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var connectionSettings = new ConnectionSettings(pool);
    				
    	var client = new ElasticClient(connectionSettings);
    	
    	client.Map<MyType>(m => m
            .Index("index-name")
    		.AutoMap()
    		.Properties(p => p
    			.String(s => s
    				.Name(n => n.CompanyName)
    				.Fields(f => f
    					.String(ss => ss
    						.Name("raw")
    						.NotAnalyzed()
    					)
    				)
    			)
    			.Date(d => d
    				.Name(n => n.CreatedDate)
    				.Index(NonStringIndexOption.No)			
    			)
    			.String(s => s
    				.Name(n => n.CompanyDescription)
    				.Store(false)
    			)
    			.Nested<MyChildType>(n => n
    				.Name(nn => nn.Locations.First())
    				.AutoMap()
    				.Properties(pp => pp
    					/* properties of MyChildType */
    				)
    			)
    		)
    	);
    }
      
    public class MyType
    {
    	// Index this & allow for retrieval.
    	public int Id { get; set; }
    
    	// Index this & allow for retrieval.
    	// **Also**, in my searching & sorting, I need to sort on this **entire** field, not just individual tokens.
    	public string CompanyName { get; set; }
    
    	// Don't index this for searching, but do store for display.
    	public DateTime CreatedDate { get; set; }
    
    	// Index this for searching BUT NOT for retrieval/displaying.
    	public string CompanyDescription { get; set; }
    
    	// Nest this.
    	public List<MyChildType> Locations { get; set; }
    }
    
    public class MyChildType
    {
    	// Index this & allow for retrieval.
    	public string LocationName { get; set; }
    
    	// etc. other properties.
    }
