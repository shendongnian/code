    class Document : IEntity, IVersionable, IDocumentContentDescription 
    {
    	public string Name { get; set; }
    	public string Description { get; set; }
    	public string MimeType { get; set; }
    	public long Length { get; set; }
    	public int Version { get; set; }
    }
    
    public interface IDocumentContentDescription
    {
    	string MimeType { get; }
    	long Length { get; }
    }
