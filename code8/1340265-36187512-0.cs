    public class LetterEntity
    {
    	public int Id { get; set; }
    	// ....
    	public List<LetterDestinationLink> Links { get; set; }
    }
    
    public class Destination
    {
    	public int Id { get; set; }
    	// ....
    	public List<LetterDestinationLink> Links { get; set; }
    }
    
    public class LetterDestinationLink
    {
    	[Key]
    	[Column(Order = 0)]
    	public int LetterId { get; set; }
    	[Key]
    	[Column(Order = 1)]
    	public int DestinationId { get; set; }
    	public LetterEntity Letter { get; set; }
    	public Destination Destination { get; set; }
    }
