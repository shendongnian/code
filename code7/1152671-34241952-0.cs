    protected virtual ActionResult CreateActionResult(ControllerContext controllerContext, ActionDescriptor actionDescriptor, object actionReturnValue)
    {
        if (actionReturnValue == null)
        {
            return new EmptyResult();
        }
        ActionResult actionResult = (actionReturnValue as ActionResult) ??
                                    new ContentResult { Content = Convert.ToString(actionReturnValue, CultureInfo.InvariantCulture) };
        return actionResult;
    }
