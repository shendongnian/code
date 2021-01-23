    public void Configuration(IAppBuilder app)
    {
        app.Use((async (context, next) =>
        {
            using (container.BeginExecutionContextScope())
            {
                await next();
            }
        }));
        ConfigureAuth(app);
    }
