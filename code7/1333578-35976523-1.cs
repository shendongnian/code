	public class MyAuthAttribute : FilterAttribute, IAuthenticationFilter
	{
		public void OnAuthentication(AuthenticationContext filterContext)
		{
			if (!filterContext.Principal.Identity.IsAuthenticated)
				filterContext.Result = new RedirectResult("Account/Login");
		}
		public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
		{
			//throw new NotImplementedException();
		}
	}
