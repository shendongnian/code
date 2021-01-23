    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var t = Task.Run(() => {
            controller = context.Controller.ToString();
            action = context.ActionDescriptor.Name;
            //Log to DB
        }
    }
