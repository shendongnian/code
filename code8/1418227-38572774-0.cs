    public class HasPermission : ActionFilterAttribute
    {
        public EnumSecuredFunctionality[] Actions { get; set; }
        public HasPermission(params EnumSecuredFunctionality[] actions)  //For example you can pass secured functionalities to restrict
        {
            Actions = actions;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            BaseController controller = (BaseController)filterContext.Controller;
            UserAuthData userAuthData = (UserAuthData)controller.ViewBag.UserAuthData;
            if (!controller.UserIsAuthenticated || !controller.ValidatePermission(userAuthData.ShopSeller.LoginName.ToString(), Actions[0]))
            {
                //REDIRECT
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "ShowMessage");
                redirectTargetDictionary.Add("controller", "Error");
                redirectTargetDictionary.Add("message", "Role " + EnumToString.EnumRoleToString(userAuthData.ShopSeller.EnumRole) + " No permissions");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
        }
    }
