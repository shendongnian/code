    public class IdRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object parameter = null;
            filterContext.ActionParameters.TryGetValue("id", out parameter);
            var id = parameter as int?;
    
            if (id == null)
            {
                var urlHelper = new UrlHelper(filterContext.Controller.ControllerContext.RequestContext);
    
                var url = urlHelper.Action("ErrorAction", "ControllerName");
    
                filterContext.Result = new RedirectResult(url);
            }
        }
    }
    ...
    [IdRequiredAttribute]
    public ActionResult Index(int id)
    {
        //...
    }
