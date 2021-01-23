    public class Employer
    {
    	public int id { get; set; }
    	public string name { get; set; }
    	public string externalId { get; set; }
    	public int networkId { get; set; }
    	public Address address { get; set; }
    }
    public class Address
    {
    
    	[JsonProperty("street_address")]
    	public string street_address { get; set; }
    	public string locality { get; set; }
    	[JsonProperty("postal_code")]
    	public string postal_code { get; set; }
    	public string region { get; set; }
    	[JsonProperty("country_name")]
    	public string country_name { get; set; }
    }
