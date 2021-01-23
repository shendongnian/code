    public class Artist : ArtistInfo
    {
    	[JsonIgnore]
    	public DateTime Created { get; set; }
    	[JsonIgnore]
    	public int CreatedById { get; set; }
    	[JsonIgnore]
    	public DateTime Updated { get; set; }
    	[JsonIgnore]
    	public int UpdatedById { get; set; }
    }
