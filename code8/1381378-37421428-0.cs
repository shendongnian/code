    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var actionName = filterContext.ActionDescriptor.ActionName;
        var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName
    
        if(controllerName == "CreateCharacter" && actionName == "Index")
        {
            base.OnActionExecuting(filterContext);
            return;
        }
    
        using (var dbCtx = new ApplicationDbContext())
        {
            var character = HttpContext.Current.GetCharacter(dbCtx);
            if (character == null)
            {
                base.OnActionExecuting(filterContext);
                return;
            }
    
            if (character.IsCreated)
            {
                base.OnActionExecuting(filterContext);
                return;
            }
    
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new {controller = "CreateCharacter", action = "Index"})
                );
    
            filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
            base.OnActionExecuting(filterContext);
        }
    }
