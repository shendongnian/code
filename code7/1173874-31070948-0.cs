    public class MyDocument
    {
    	public int Id { get; set; } 
    	[ElasticProperty(TermVector = TermVectorOption.WithPositionsOffsets)]
    	public string Description { get; set; }
    }
