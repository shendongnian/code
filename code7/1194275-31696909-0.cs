        public class AuthorizeService : AuthorizeAttribute
        {
            private UserService UserService
            {
                get
                {
                    return DependencyResolver.Current.GetService<UserService>();
                }
            }
    
            public bool AuthorizeCore(HttpContextBase httpContext, Privilege privilege)
            {
                ApplicationUser user = UserService.FindByName(httpContext.User.Identity.Name);
                return UserService.UserHasPrivilege(user.Id, privilege.ToString());
            }
        }
 
