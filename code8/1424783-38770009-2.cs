    public override async Task ExecuteResultAsync(ActionContext context)
    {
        if (context == null)
        {
             throw new ArgumentNullException(nameof(context));
        }
        var services = context.HttpContext.RequestServices;
        var executor = services.GetRequiredService<ViewResultExecutor>();
        var result = executor.FindView(context, this);
        result.EnsureSuccessful(originalLocations: null);
        var view = result.View;
        using (view as IDisposable)
        {
             await executor.ExecuteAsync(context, view, this);
        }
    }
