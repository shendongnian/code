    [AttributeUsage(AttributeTargets.Class | 
                             AttributeTargets.Method
                           , AllowMultiple = true
                           , Inherited = true)]
    public class CheckAccessAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
      private string[] _permission;
      public CheckAccessAttribute(params string[] permission)
      {
          _permission = permission;
      }
      public void OnAuthorization(AuthorizationFilterContext context)
      {
         var user = context.HttpContext.User;
         if (!user.Identity.IsAuthenticated)
         {
            return;
         }
         IRepository service = 
         (IRepositoryWrapper)context.HttpContext.RequestServices.GetService(typeof(IRepository));
         var success = service.CheckAccess(userName, _permission.ToList());
         if (!success)
         {
            context.Result = JsonFormatter.GetErrorJsonObject(
                                   CommonResource.error_unauthorized,
                                   StatusCodeEnum.Forbidden);
            return;
         }
         return;
       }
    }
