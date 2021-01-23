    public static IApplicationBuilder UseOwinAppBuilder(this IApplicationBuilder app, Action<IAppBuilder> configuration) {
        if (app == null) {
            throw new ArgumentNullException(nameof(app));
        }
    
        if (configuration == null) {
            throw new ArgumentNullException(nameof(configuration));
        }
    
        return app.UseOwin(setup => setup(next => {
            var builder = new AppBuilder();
            var lifetime = (IApplicationLifetime) app.ApplicationServices.GetService(typeof(IApplicationLifetime));
    
            var properties = new AppProperties(builder.Properties);
            properties.AppName = app.ApplicationServices.GetApplicationUniqueIdentifier();
            properties.OnAppDisposing = lifetime.ApplicationStopping;
            properties.DefaultApp = next;
    
            configuration(builder);
    
            return builder.Build<Func<IDictionary<string, object>, Task>>();
        }));
    }
