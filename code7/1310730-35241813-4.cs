    public class AddFirstMobile
	{
		[DisplayName("Mobile Number")]
		[Required(ErrorMessage = "* Please Enter Mobile Number")]
		public string MobileNo { get; set; }
	}
	
	
	public class MobileViewModel
	{
		public AddFirstMobile FirstMobileNumber{get;set;}
		
		public AddFirstMobile SecondMobileNumber{get;set;}
	}
