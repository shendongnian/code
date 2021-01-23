    public class AuthorizeMultipleAttribute : AuthorizeAttribute
    {
       //Authorize multiple roles
       public string MultipleRoles { get; set; }
      protected override bool AuthorizeCore(HttpContextBase httpContext)
      {
          var isAuthorized = base.AuthorizeCore(httpContext);
          if (!isAuthorized)
          {                
            return false;
          }
          //Logic here
          //Note: Make a split on MultipleRoles, by ','
          //User is in both roles => return true, else return false
      }
    }
