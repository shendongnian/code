    public class ListingResponse
    {
        [JsonProperty("listinginfo")]
    	public Dictionary<string, NewListedItem> Items { get; set; }
    }
