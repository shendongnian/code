	public static bool isInRole(IPrincipal User, string roleName, ApplicationDbContext dbContext)
	{
		try
		{
			var store = new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(dbContext);
			var manager = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(store);
			return manager.IsInRole(User.Identity.GetUserId(), roleName);
		}
		catch (Exception ex)
		{
			return false;
		}
		return false;
	}
