    public class AccountWrapper
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        //Add this line
    	[JsonProperty("result")]
        public List<AccountCurrencies> AccountAllCurrencies  { get; set; }
    }
