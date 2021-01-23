    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        actionContext.Request.Properties.Add(this.GetType().FullName, Stopwatch.StartNew());
        base.OnActionExecuting(actionContext);
    }
