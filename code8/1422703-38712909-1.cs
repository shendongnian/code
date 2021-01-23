	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public virtual ICollection<ApplicationUserRole> Roles { get; set; }
		
		.............
	}
