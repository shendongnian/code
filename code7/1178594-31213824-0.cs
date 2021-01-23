    public class CustomAuthorize: AuthorizeAttribute    
     {
    
         protected override void HandleUnauthorizedRequest(AuthorizationContext    
         filterContext)    
         {     
               if (IsUserAuthenticated(filterContext.HttpContext))    
               {    
                filterContext.Result = new   RedirectResult("/Account/InvalidRole");    
               }    
               else    
               {    
                base.HandleUnauthorizedRequest(filterContext);    
               }    
         }
    
         private bool IsUserAuthenticated(HttpContextBase context)    
         {    
                return context.User != null && context.User.Identity != null &&     
                context.User.Identity.IsAuthenticated;    
         }
    
     }
