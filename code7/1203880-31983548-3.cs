    using Microsoft.AspNet.Mvc;
    using Microsoft.AspNet.Authorization;
    services.ConfigureMvc(options =>
    {
       options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
    });
