    public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            Func<string, Type> getControllerType = ctrlName =>
            {
                var action = requestContext.RouteData.Values["action"].ToString();
                var types = new List<Type>();
                //It's a route and not a sitecore item
                if (SC.Context.Item == null || SC.Context.Item.Visualization.Layout == null)
                {
                    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    foreach (var type in assemblies.Select(assembly => assembly.DefinedTypes.FirstOrDefault(x => x.Name == string.Concat(controllerName, "Controller"))).Where(type => type != null))
                    {
                        if (!string.IsNullOrEmpty(action))
                        {
                            var method = type.GetMethod(action);
                            if (method != null && !method.IsAbstract && !method.IsConstructor &&
                                !method.IsGenericMethod)
                            {
                                return type;
                            }
                        }
                        types.Add(type);
                    }
                    return types.FirstOrDefault();
                }
                return TypeHelper.GetType(controllerName);
            };
            var controller = getControllerType(controllerName);
            return GetControllerInstance(requestContext, controller);
        }
