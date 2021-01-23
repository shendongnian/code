    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
            if (UserService.IsLoggedIn())
            {
                model.IsLoggedIn = true;
                model.CurrentUser = UserService.GetCurrentUser();
                model.UserProfile = svc.GetByUserId(model.CurrentUser.Id);
                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
                var actionName = filterContext.ActionDescriptor.ActionName.ToLower();
                if (controllerName != "user" && actionName != "onboard" && model.UserProfile.OnboardStatus == 0)
                {
                    HttpContext.Response.Redirect("/user/onboard/"+ model.UserProfile.Id);
                    }
                }
    }
