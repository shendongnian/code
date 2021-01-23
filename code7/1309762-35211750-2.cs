    public class UserRoleAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Data Repository. Getting data from database
            var repository = new LoginRoleRepository();
            //GetCharacterSeparator is an Extension method of String class
            //It seperates the comma separated roles.
            //The data comes from the controller
            var roles = Roles.GetCharacterSeparator(',', true);
            
            if (httpContext.User.Identity.IsAuthenticated)
            {
                //Here I check if the user is in the role, you can have your own logic. The data is gotten from DB.
                var userRoles =
                    repository.All().Where(obj => obj.Login.Username == httpContext.User.Identity.Name).Single().Roles;
                
                foreach (var role in roles)
                    if (userRoles.Any(obj => obj.Name == role))
                        return true;
            }
            return false;
        }
    }
