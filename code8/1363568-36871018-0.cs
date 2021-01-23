    public override void OnActionExecuting(ActionExecutingContext context)
    {       
        if (context.HttpContext.Request.Headers["X-Requested-With"] != null &&
            context.HttpContext.Request.Headers["X-Requested-With"] == "XmlHttpRequest")
        {
            context.Result = new JsonResult {Data = new {Authenticated = false,
                                                           Message = "Please login"}};
        }
    }
