    public class BearerRequirement : IAuthorizationRequirement
    {
        public async Task<bool> IsTokenValid(SomeValidationContext context, string token)
        {
            // here you can check if the token received is valid 
            return true;
        }
    }
    public class BearerAuthorizationHandler : AuthorizationHandler<BearerRequirement> 
    {
        public BearerAuthorizationHandler(SomeValidationContext thatYouCanInject)
        {
           ...
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BearerRequirement requirement)
        {
            var authFilterCtx = (Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)context.Resource;
            string authHeader = authFilterCtx.HttpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.Contains("Bearer"))
            {
                var token = authHeader.Replace("Bearer ", string.Empty);
                if (await requirement.IsTokenValid(thatYouCanInject, token))
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
