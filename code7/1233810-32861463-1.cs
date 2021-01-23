    public class RootJson
    {
    	[JsonProperty("cinemaSF")]
    	public cinemaSF csf { get; set; }
    }
    
    public class cinemaSF
    {
    	[JsonProperty("customer_id")]
    	public string customer_id { get; set; }
    	[JsonProperty("ticket")]
    	public List<ticket> ticket_cinemaSF { get; set; }
    	[JsonProperty("dur_info")]
    	public List<dur_info> dur_info_cinemaSF { get; set; }
    	[JsonProperty("cine_event")]
    	public List<driving_event> driving_event_cinemaSF { get; set; }
    }
