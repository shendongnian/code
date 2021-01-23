    public void Configure(IApplicationBuilder app,
        IApplicationLifetime applicationLifetime)
    {
        // Pipeline setup code ...
        applicationLifetime.ApplicationStopping.Register(() => { 
            // notify long-running tasks of pending doom  
        });
    }
