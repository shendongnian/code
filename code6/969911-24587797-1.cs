    var result = JsonConvert.DeserializeObject<Result>(json);  
  
   	public class Result
	{
		public string refresh_token { get; set; }
		public int expires_in { get; set; }
		public string access_token { get; set; }
		public string token_type { get; set; }
		public string x_mailru_vid { get; set; }
	}
