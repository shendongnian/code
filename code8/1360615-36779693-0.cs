    public class TestflowFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var profileId = int.Parse(ClaimsPrincipal.Current.GetClaimValue("UserId"));
            var appId = int.Parse(filterContext.RouteData.Values["id"].ToString());
            if (profileId != 0 && appId != 0)
            {
                if (CheckIfValid(profileId, appId))
                {
                    // redirect
                    filterContext.Result = // url to go to
                }
            }
        }
    }
