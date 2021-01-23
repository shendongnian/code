	public class Location
	{
	    public int LocationId { get; set; }
	
	    public string LocationName { get; set; }
	
	    public ICollection<Place> Places { get; set; }
	}
	
	public class Place
	{
	    public int PlaceId { get; set; }
	
	    public string PlaceName { get; set; }
	
	    public int LocationId { get; set; }
	
	    public Location Location { get; set; }
	
	    public ICollection<AttractionPlace> Attractions { get; set; }
	}
	
	public class Attraction
	{
	    public int AttractionId { get; set; }
	
	    public string AttractionName { get; set; }
	}
	
	public class AttractionPlace
	{
	    public int AttractionPlaceId { get; set; }
	
	    public int PlaceId { get; set; }
	
	    public Place Place { get; set; }
	
	    public int AttractionId { get; set; }
	
	    public Attraction Attraction { get; set; }
	}
