    namespace MyProject.MyExtensions
	{
		public static class MyUserPrincipalExtension
		{
			public static string MyProperty(this ClaimsPrincipal user)
			{
				if (user.Identity.IsAuthenticated)
				{
					return user.Claims.FirstOrDefault(v => v.Type == ClaimTypes.Email).Value;
				}
				return "";
			}
		}
	}
