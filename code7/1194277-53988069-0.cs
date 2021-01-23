    public class CustomAuthAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            // var user = context.HttpContext.User;
            // if (!user.Identity.IsAuthenticated)
            // {
            //     context.Result = new UnauthorizedResult();
            //     return;
            // }
            var userService = context.HttpContext.RequestServices.GetService(typeof(UserService)) as UserService;
        }
    }
