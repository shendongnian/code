    public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller = SC.Context.Item == null || SC.Context.Item.Visualization.Layout == null
                            ? base.GetControllerType(requestContext, controllerName)
                            : TypeHelper.GetType(controllerName);
            return GetControllerInstance(requestContext, controller);
        }
