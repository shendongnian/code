    void Main()
    {
    	var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
    	
        // use NEST *ElasticClient*
    	var client = new ElasticClient(settings, connection: new InMemoryConnection());
    
    	var docs = new List<Doc>
    	{
    		new Doc(),
    		new Doc(),
    		new Doc(),
    		new Doc(),
    		new Doc()
    	};
    	
    	var indexResponse = client.CreateIndex("docs", c => c
    		.AddMapping<Doc>(m => m.MapFromAttributes())
    	);
    	
    	var bulkResponse = client.Bulk(b => b
    		.IndexMany(docs, (d, doc) => d.Document(doc).Index("index-name").Type("type-name"))
    	);
    }
    
    public class Doc
    {
    	public Doc()
    	{
     		Id = Guid.NewGuid();
    	}
    	
    	public Guid Id { get; set; }
    }
