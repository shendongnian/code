    public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;
            //store user.Claims in property so inherited controllers have access
            base.OnActionExecuting(context);
        }
