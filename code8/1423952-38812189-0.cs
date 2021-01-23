    void Main()
    {
    	var node = new Uri("http://localhost:9200");
    	var settings = new ConnectionSettings(node)
            // default index to use if one is not specified on the request
            // or is not set up to be inferred from the POCO type
    		.DefaultIndex("tests");
    
    	var client = new ElasticClient(settings);
    
    	// create the index, and explicitly provide a mapping for TestType
    	client.CreateIndex("tests", c => c
    		.Mappings(m => m
    			.Map<TestType>(t => t
    				.AutoMap()
    			)
    		)
    	);
    
    	var testItem = new TestType { Id = Guid.NewGuid(), Name = "Test", Value = "10" };
    
    	// now index our TestType instance
    	var response = client.Index(testItem);
    }
    
    public class TestType
    {
    	public Guid Id { get; set; }
    	public string Name { get; set; }
    	public decimal Value { get; set; }
    }
