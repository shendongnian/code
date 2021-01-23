	using System;
	using System.Web.Mvc;
	using System.Security.Principal;
	public class GetUserActionFilter : IActionFilter
	{
		private readonly IUserRepository userRepository;
		public GetUserActionFilter(IUserRepository userRepository)
		{
			if (userRepository == null)
				throw new ArgumentNullException("userRepository");
			this.userRepository = userRepository;
		}
		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			// Do nothing - this occurs after the action method has run
		}
		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			IPrincipal user = filterContext.HttpContext.User;
			
			if (user == null)
			{
				return;
			}
			IIdentity identity = user.Identity;
			if (identity == null)
			{
				return;
			}
			// Make sure we have a valid identity and it is logged in.
			if (identity.IsAuthenticated)
			{
				string key = "__CurrentUserData";
				var userData = filterContext.HttpContext.Session[key];
				if (userData == null)
				{
					// User data doesn't exist in session, so load it
					userData = userRepository.GetUserData(identity.Name);
					// Add it to session state
					filterContext.HttpContext.Session[key] = userData;
				}
			}
		}
	}
