    public class DocumentPartial
    { 
    	public int[] Array { get; set; }
    }
    
    public class Document
    {
    	public int Id { get; set; } 
    
    	public int[] Array { get; set; }
    }
    
    var client = new ElasticClient(settings); 
    
    client.CreateIndex(indexName, descriptor => descriptor
    	.Mappings(map => map
    		.Map<Document>(m => m.AutoMap()))); 
    
    var items = new List<Document>
    {
    	new Document
    	{
    		Id = 1, 
    		Array = new[] {1,2,3}
    	} 
    };
    
    var bulkResponse = client.IndexMany(items);
    
    client.Refresh(indexName);
    
    var updateResponse = client.Update<Document, DocumentPartial>(DocumentPath<Document>.Id(1), descriptor => descriptor
    	.Script(@"ctx._source.array += tab; ctx._source.array.unique();")
    	.Params(p => p.Add("tab", new[] {4, 5, 3})));
