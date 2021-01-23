    public class CustomController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CustomUser user = Session["User"] as CustomUser;
            if(user != null && user.CanAccessFeature("TopicModeration"))
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult("Default.aspx?featureDenied=TopicModeration", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
