        private static IEnumerable<Type> GetTypesWithFixedControllerRouteAttribute(RouteCollection routes)
                {
                                                             //This is where i am passing the variables
                    foreach (Type type in Assembly.GetAssembly(typeof(Controllers.HomeController)).GetTypes())
                    {
                        // Register any fixed actions
                        RegisterFixedActionRoutes(type, routes);
        
                        if (type.GetCustomAttributes(typeof(FixedControllerRouteAttribute), true).Any())
                        {
                            yield return type;
                        }
                    }
                }
