    public class EventWithHeadlinersDto
    {
    	// Event Info
    	public int EventId { get; set; }
    	public string EventName { get; set; }
    	public string EventSlug { get; set; }
    	// Artist Info
    	public int? ArtistId { get; set; }
    	public string ArtistName { get; set; }
    	public string ArtistBio { get; set; }
    }
