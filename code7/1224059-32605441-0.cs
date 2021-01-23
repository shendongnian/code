    if (page == null)
    {
        // Move to next router
        return;
    }
    // TODO: Replace with correct controller
    var controllerType = typeof(HomeController);
    // TODO: Replace with correct action
    var action = nameof(HomeController.Index);
    // This is used to locate the razor view
    // Remove the trailing "Controller" string
    context.RouteData.Values["Controller"] = controllerType.Name.Substring(0, controllerType.Name.Length - 10);
    var actionInvoker = context.HttpContext.RequestServices.GetRequiredService<IActionInvokerFactory>();
    var descriptor = new ControllerActionDescriptor
    {
        Name = action,
        MethodInfo = controllerType.GetTypeInfo().DeclaredMethods.Single(m => m.Name == action),
        ControllerTypeInfo = controllerType.GetTypeInfo(),
        // Setup filters
        FilterDescriptors = new List<FilterDescriptor>(),
        // Setup DI properties
        BoundProperties = new List<ParameterDescriptor>(0),
        // Setup action arguments
        Parameters = new List<ParameterDescriptor>(0),
        // Setup route constraints
        RouteConstraints = new List<RouteDataActionConstraint>(0),
        // This router will work fine without these props set
        //ControllerName = "Home",
        //DisplayName = "Home",
    };
    var accessor = context.HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>();
    accessor.ActionContext = new ActionContext(context.HttpContext, context.RouteData, descriptor);
    var actionInvokerFactory = context.HttpContext.RequestServices.GetRequiredService<IActionInvokerFactory>();
    var invoker = actionInvokerFactory.CreateInvoker(accessor.ActionContext);
    // Render the page
    await invoker.InvokeAsync();
    // Don't execute the next IRouter
    context.IsHandled = true;
    return;
