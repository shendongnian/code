    public class ItemSummaryModel
    {
    	[JsonProperty(PropertyName = "2")]
    	public ItemSummary Two { get; set; }
    	[JsonProperty(PropertyName = "6")]
    	public ItemSummary Six { get; set; }
    	[JsonProperty(PropertyName = "8")]
    	public ItemSummary Eight { get; set; }
    }
    var result = JsonConvert.DeserializeObject<ItemSummaryModel>(json);
