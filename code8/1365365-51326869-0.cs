    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
    }
    else
    {
        var exceptionHandlingOptions = new ExceptionHandlerOptions()
        {
            ExceptionHandler = ExceptionHandler.OnException // !! this is the key line !!
            // ExceptionHandlingPath = "/Home/Error"
            // according to my tests, the line above is useless when ExceptionHandler is set
            // after OnException completes the user would receive empty page if you don't write to Resonse in handling method
            // alternatively, you may leave ExceptionHandlingPath without assigning ExceptionHandler and call ExceptionHandler.OnException in controller's action instead
            // write me if you need a sample code
        };
        app.UseExceptionHandler(exceptionHandlingOptions);
    }
    public static class ExceptionHandler
    {
        public static async Task OnException(HttpContext context)
        {
            var feature = context.Features.Get<IExceptionHandlerFeature>();
    
            var exception = feature?.Error;
    
            if (exception == null) return;
    
            //TODO: log exception here
        }
    }
