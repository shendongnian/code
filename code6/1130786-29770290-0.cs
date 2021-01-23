    void Main()
    {
    	var jsonString = File.ReadAllText(@"C:\text.json");
    	var json = JsonConvert.DeserializeObject<Response>(jsonString);
    }
    
    public class Response
    {
        public Outcomes[] outcomes { get; set; }
    }
    
    public class Outcomes
    {
    	[JsonProperty("outcome_coef")]
        public float OutcomeCoef { get; set; }
    	[JsonProperty("outcome_id")]
        public int OutcomeId { get; set; }
    }
