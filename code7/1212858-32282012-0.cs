        public static IApplicationBuilder UseMvc(this IApplicationBuilder app,Action<IRouteBuilder> configureRoutes)
            {
                MvcServicesHelper.ThrowIfMvcNotRegistered(app.ApplicationServices);
                var routes = new RouteBuilder
                {
                    DefaultHandler = new MyRouteHandler(),
                    ServiceProvider = app.ApplicationServices
                };
