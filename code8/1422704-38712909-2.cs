	public class ApplicationUserRole : IdentityUserRole
	{
		public ApplicationUserRole()
			: base()
		{ }
		public virtual ApplicationRole Role { get; set; }
	}
