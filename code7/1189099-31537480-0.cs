    public class MyAuthorizeAttribute: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool accessAllowed = false;
            bool isInGroup = false;
            List<string> roleValues = Roles.Split(',').Select(rValue => rValue.Trim().ToUpper()).ToList();
            foreach (string role in roleValues)
            {
                isInGroup = IdentityExtensions.UserHasRole(httpContext.User.Identity, role);
                if (isInGroup)
                {
                    accessAllowed = true;
                    break;
                }
            }
            //add any other validation here
            //if (actionContext.Request.IsLocal()) accessAllowed = true;
            if (!accessAllowed)
            {
                //do some logging
            }
            return accessAllowed;
        }
    ...
    }
