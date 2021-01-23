    public class Data
    {
    	[JsonProperty("ID")]
        public int Id { get; set; }
    	[JsonProperty("value")]
        public double Value { get; set; }
    }
    
    public class Account
    {
    	[JsonProperty("type")]
        public string Type { get; set; }
        public List<Data> Data { get; set; }
    	[JsonProperty("Datetime")]
        public string DateTime { get; set; }
    	[JsonProperty("customerID")]
        public int CustomerId { get; set; }
    }
