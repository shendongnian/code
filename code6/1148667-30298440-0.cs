	void Example()
	{
		var clients = new DisabilityCode[1].Where(dc 	  => dc.Code == "Ast")
										   .SelectMany(dc => dc.Enquiries)
										   .Select(etd    => etd.ClientEnquiry)
										   .Select(ce     => ce.Client.ClientId);
										//     or
										// .Select(ce     => ce.Client)
										// .Select(c      => c.ClientId);
			
	}
	
	public class DisabilityCode
	{
		public string DisabilityId { get; set; }
		public string Code { get; set; }
		public virtual ICollection<ClientEnquiryToDisabilityCode> Enquiries { get; set; }
	}
	
	public class ClientEnquiry
	{
		public string ClientEnquiryId { get; set; }
		public string ClientId { get; set; }
		
		public virtual Client Client { get; set; }
		public virtual ClientEnquiryToDisabilityCode DisabilityCode { get; set; }
	}
	
	public class ClientEnquiryToDisabilityCode
	{
		public string ClientEnquiryId { get; set; }
		public string DisabilityCodeId { get; set; }
		
		public virtual ClientEnquiry ClientEnquiry { get; set; }
		public virtual DisabilityCode DisabilityCode { get; set; }
	}
	
	public class Client
	{
		public string ClientId { get; set; }
		public virtual ICollection<ClientEnquiry> Enquiries { get; set; }
	}
