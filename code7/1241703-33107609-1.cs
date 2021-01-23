    public class LoggedUserParameterAttribute : ActionFilterAttribute
    {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
    
                // Get the User (you have to adjust your code here)                
                var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
    
                // 'Assemble' your logged user with all the needed information
                var userViewModel = UserViewModel {
                    UserName = user.UserName,
                    SecurityStamp = user.SecurityStamp
                }
    
                // Create an optional action parameter 'loggedUser'
                filterContext.ActionParameters["loggedUser"] = userViewModel;
            }
    }
