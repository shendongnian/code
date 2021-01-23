    public class Document
    {
    	public string TextID { get; set; }
    }
    
    var searchResponse = client.Search<Document>(sd => sd
    	.Index("index")
    	.Type("type")
    	.Size(10000)
    	.Query(q => q
    		.Match(m => m.Field("TextID").Query("WT")
    		)));
