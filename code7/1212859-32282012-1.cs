        public static IApplicationBuilder UseMyMvc(this IApplicationBuilder app,Action<IRouteBuilder> configureRoutes)
            {
                MvcServicesHelper.ThrowIfMvcNotRegistered(app.ApplicationServices);
                var routes = new RouteBuilder
                {
                    DefaultHandler = new MyNamespace.MvcRouteHandler(),
                    ServiceProvider = app.ApplicationServices
                };
             //..... rest of the code of this method here...
            }
