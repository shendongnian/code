    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class RequiresSerialValidationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
			bool hasValidSerial = false;
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                string userName = filterContext.HttpContext.User.Identity.Name;
                if (!string.IsNullOrWhiteSpace(userName))
                {		
					string serial = string.Empty;// TODO: Retrieve user's previously authenticated serial, perhaps from Session or a cookie?
					
					if(!string.IsNullOrWhiteSpace(serial))
					{
						var service = DependencyResolver.Current.GetService<IYourAuthService>();
						hasValidSerial = service.IsSerialValidForUser(userName, serial);
					}
                }
            }
			
			if (!hasValidSerial)
			{
				filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "yourserialauthcontroller", action = "yourauthaction", area = string.Empty }));
			}
			else
			{
				base.OnAuthorization(filterContext);
			}
        }
    }
