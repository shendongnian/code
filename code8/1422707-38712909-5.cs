	public class ApplicationUser 
		: IdentityUser<string, IdentityUserLogin, ApplicationUserRole, IdentityUserClaim>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		
		.............
	}
