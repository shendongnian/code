	public class ApplicationUser : IdentityUser<Guid>
	{
	}
	public class GuidDataContext :
		IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
	}
