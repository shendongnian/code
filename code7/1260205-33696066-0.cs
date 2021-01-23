    public class Something3
    {
    	public int Something4 { get; set; }
    	public int Something5 { get; set; }
    	public int Something6 { get; set; }
    	public int Id { get; set; }
    }
    
    public class Status
    {
    	public string Caption { get; set; }
    	public int Value { get; set; }
    }
    
    public class RootObject
    {
    	public int Something { get; set; }
    	public int Something2 { get; set; }
    	public Something3 Something3 { get; set; }
    	public int Something7 { get; set; }
    	public int SomethingId { get; set; }
    	public string Something8 { get; set; }
    	public Status Status { get; set; }
    	public string Type { get; set; }
    	public int Id { get; set; }
    	[JsonProperty("@Delete")]
    	public bool Delete { get; set; }
    	public string Something9 { get; set; }
    }
