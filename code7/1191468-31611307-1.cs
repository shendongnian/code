    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        Stopwatch stopWatch = null;
        if (actionExecutedContext.Request.Properties.ContainsKey(this.GetType().FullName))
            stopWatch = actionExecutedContext.Request.Properties[this.GetType().FullName] as Stopwatch;
        if (stopWatch != null)
        {
            var elapsedTime = stopWatch.ElapsedMilliseconds;
            // do something with that value
        }
        base.OnActionExecuted(actionExecutedContext);
    }
