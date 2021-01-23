    public class IsAdminOrAuthorizeFilter : AuthorizeFilter
    {
        public IsAdminOrAuthorizeFilter(AuthorizationPolicy policy): base(policy)
        {
        }
        public override Task OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext context)
        {
            // If there is another authorize filter, do nothing
            if (context.Filters.Any(item => item is IAsyncAuthorizationFilter && item != this))
            {
                return Task.FromResult(0);
            }
            //Otherwise apply this policy
            return base.OnAuthorizationAsync(context);
        }        
    }
    services.AddMvc(opts => 
    {
        opts.Filters.Add(new IsAdminOrAuthorizeFilter(new AuthorizationPolicyBuilder().RequireRole("admin").Build()));
    });
