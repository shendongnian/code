    public class AuditUpdateListener : IPostUpdateEventListener
    {
        public void OnPostUpdate(PostUpdateEvent @event)
        {
          var httpContext = CallContext.HostContext as HttpContext;
          var ipAddress = httpContext.Request.UserHostAddress;
          var username = httpContext.User.Identity.Name;
          // some code to get values from httpContext.Request.Cookies
        }
    }
