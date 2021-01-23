    public void Configure(IAppBuilder app)
    {
        app.UseWhen(context => context.Request.Path.ToString().StartsWith("/test1"), testApp1 =>
        {
            app.UseMvc();
        });
        app.UseWhen(context => context.Request.Path.ToString().StartsWith("/test2"), testApp1 =>
        {
            app.UseMvc();
        });
    }
    public static class AppExtensions {
        public static IApplicationBuilder UseWhen(this IApplicationBuilder app
            , Func<Microsoft.AspNetCore.Http.HttpContext, bool> condition
            , Action<IApplicationBuilder> configuration)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            var builder = app.New();
            configuration(builder);
            return app.Use(next => {
                builder.Run(next);
                var branch = builder.Build();
                return context => {
                    if (condition(context))
                    {
                        return branch(context);
                    }
                    return next(context);
                };
            });
        }
    }
