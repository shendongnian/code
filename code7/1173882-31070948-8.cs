    public class MyDocument
    {
    	public int Id { get; set; } 
    	[ElasticProperty(TermVector = TermVectorOption.WithPositionsOffsets)]
    	public string Description { get; set; }
    	[ElasticProperty(Type = FieldType.Attachment, TermVector =TermVectorOption.WithPositionsOffsetsPayloads, Store = true, Index = FieldIndexOption.Analyzed)]
    	public Attachment File { get; set; }
    }
