        public class CustomAuthorizeAttribute : AuthorizeAttribute  
        {  
           protected override bool AuthorizeCore(HttpContextBase httpContext)  
           { 
             // Get the entity of the logged in user 
             var userEntity = GetLoggedInUser(httpContext);
    
             // If the user is not found, return false.
             if (userEntity == null)
             {
                 return false;
             }
           }
           private User GetLoggedInUser(HttpContextBase httpContext)
           {
             // return the current user
           }
        }
