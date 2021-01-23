     public class DashBoardAuthorizeAttribute : AuthorizeAttribute 
        {
            /// <summary>
            /// Handles the unauthorized request.
            /// </summary>
            /// <param name="context">The context.</param>
            protected override void HandleUnauthorizedRequest(AuthorizationContext context)
            {
                var newName = "UserContext" + HttpContext.Current.User.Identity.Name;
                var cache = MemoryCache.Default;
                var userContext = cache.Get(newName) as IUserModel;
                if (userContext != null && !userContext.DashBoardAccess)
                {
                    var urlHelper = new UrlHelper(context.RequestContext);
                    var address = urlHelper.Action("Index", "Home");
                    context.Result = new RedirectResult(address ?? "login");
                }
                else
                {
                    base.HandleUnauthorizedRequest(context);
                }
            }
        }
