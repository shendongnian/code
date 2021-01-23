	public class GuidIdentityUser : IdentityUser<Guid>
	{
	}
	public class GuidDataContext :
		IdentityDbContext<GuidIdentityUser, IdentityRole<Guid>, Guid>
	{
	}
