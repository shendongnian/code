    public class AddFirstMobileViewModel
	{
		[DisplayName("Mobile Number")]
		[Required(ErrorMessage = "* Please Enter Mobile Number")]
		public string MobileNo { get; set; }
	}
	
	public class AddSecondMobileViewModel
	{
		[DisplayName("Mobile Number")]
		[Required(ErrorMessage = "* Please Enter Mobile Number")]
		public string MobileNo { get; set; }
	}
	
	public class MobileViewModel
	{
		public AddFirstMobile FirstMobileNumber{get;set;}
		
		public AddSecondMobile SecondMobileNumber{get;set;}
	}
