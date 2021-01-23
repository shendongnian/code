		public class Example 
		{
			[JsonProperty("receiver_tax_id")] 
			public string ReceiverTaxId { get; set; }
			
			[JsonProperty("total")] 
			public string Total { get; set; }
			
			[JsonProperty("receiver_company_name")] 
			public string ReceiverCompanyName { get; set; }
			
			[JsonProperty("receiver_email")] 
			public string ReceiverEmail { get; set; }
			
			[JsonProperty("status")] 
			public int Status{ get; set; } 
		}
		
