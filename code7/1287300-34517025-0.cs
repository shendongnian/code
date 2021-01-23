    public sealed class ModuleAccessAuthorizationAttribute : System.Web.Http.Filters.IAuthorizationFilter {
       public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation) {
          var resolver = actionContext.Request.GetDependencyScope();
          var authenticationFactory = resolver.GetService<IAuthenticationFactory>();
          // rest of implementation executing an authorization check
       }
    }
