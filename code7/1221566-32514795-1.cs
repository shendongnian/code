    public class RootObject
    {
        [JsonProperty("Report")]
        public Report Reports { get; set; }
    }
    public class Report
    {
    	[JsonProperty("Report")]
        public Dictionary<WorkItem> Item;
    }
    
    public class WorkItem
    {
    	[JsonProperty("ID")]
        public string ID { get; set; }
    	[JsonProperty("Age")]
        public int Age { get; set; }
    	[JsonProperty("Details")]
        public Dictionary<Details> Details { get; set; }
    }
    
    public class Details
    {
    	[JsonProperty("Status")]
        public string Status { get; set; }
    	[JsonProperty("Name")]
        public string Name { get; set; }
    }
