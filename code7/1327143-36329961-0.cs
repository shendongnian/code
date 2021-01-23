    public static class PrincipalExtensions
    {
		public static string ProfilePictureUrl(this ClaimsPrincipal user, UserManager<ApplicationUser> userManager)
		{
			if (user.Identity.IsAuthenticated)
			{
				var appUser = userManager.FindByIdAsync(user.GetUserId()).Result;
				return appUser.ProfilePictureUrl;
			}
			return "";
		}
    }
