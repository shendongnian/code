    public class BearerRequirement : IAuthorizationRequirement
    {
        public BearerRequirement(/* here you can inject some context that will help validate token */)
        {
        }
        public async Task<bool> IsTokenValid(string token)
        {
            // here you can check if the token received is valid 
            return true;
        }
    }
    public class BearerAuthorizationHandler : AuthorizationHandler<BearerRequirement> 
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BearerRequirement requirement)
        {
            var authFilterCtx = (Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)context.Resource;
            string authHeader = authFilterCtx.HttpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.Contains("Bearer"))
            {
                var token = authHeader.Replace("Bearer", "");
                if (await requirement.IsTokenValid(token))
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
