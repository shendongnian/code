    public class QuarterlySales
    {
    	[JsonProperty(Order = 1)]
    	public string _TimePeriod { get; set; }
    
    	[JsonProperty(Order = 2)]
    	public double _Mouse { get; set; }
    
    	[JsonProperty(Order = 3)]
    	public double _KeyBoard { get; set; }
    
    	[JsonProperty(Order = 4)]
    	public double _Printer { get; set; }        
    }
