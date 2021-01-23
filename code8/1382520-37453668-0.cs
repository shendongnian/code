    public class ApplicationBaseController : Controller
    {
        public ApplicationBaseController()
        {
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Define your UserName
            Session["Username"] = "Admin User";
            //Some code if you want to add
            base.OnActionExecuted(filterContext);
        }
    }
