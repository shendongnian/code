    public class CookieFilterAttribute : AuthorizeAttribute
    {
        [Inject]
        public IUserService UserService { get; set; }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            CookieHeaderValue cookie = actionContext.Request.Headers.GetCookies("session").FirstOrDefault();
            var isAuthenticated = UserService.IsAuthenticated(cookie);
            return isAuthenticated;
        }
    }
