	public sealed class Airport
	{
		[Key]
	    public Guid Id { get; set; }
	    public string IATA { get; set; }       
	    public string Name { get; set; }
	    public ICollection<AirportTerminal> Terminals { get; set; }
	}
    public class AirportTerminal
	{
		[Key]
	    public Guid Id { get; set; }
	    public string IATA { get; set; }
	    public string Terminal { get; set; }
	    public Airport Airport { get; set; }
	    public Guid? AirportId { get; set; }
	}
