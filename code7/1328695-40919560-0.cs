    public class IsAdminOrAuthorizeFilter : AuthorizeFilter
    {
        public IsAdminOrAuthorizeFilter(AuthorizationPolicy policy): base(policy)
        {
        }
        public override Task OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext context)
        {
            if (context.Filters.Any(f =>
            {
                var filter = f as AuthorizeFilter;
                //There's 2 default Authorize filter in the context for some reason...so we need to filter out the empty ones
                return filter?.AuthorizeData != null && filter.AuthorizeData.Any() && f != this;
            }))
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
