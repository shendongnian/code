    public class AllowAnonymousOnlyAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                bool userId = HttpContext.Current.User.Identity.IsAuthenticated;
                if (userId)
                {
                    if (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("Doctor"))
                    {
                        filterContext.HttpContext.Response.Redirect("/Home/Index");
                        
                    }
                }
                base.OnActionExecuting(filterContext);
            }
        }
 
