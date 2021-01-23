    /// <summary>Creates the action result.</summary>
    /// <returns>The action result object.</returns>
    /// <param name="controllerContext">The controller context.</param>
    /// <param name="actionDescriptor">The action descriptor.</param>
    /// <param name="actionReturnValue">The action return value.</param>
    protected virtual ActionResult CreateActionResult(ControllerContext controllerContext, ActionDescriptor actionDescriptor, object actionReturnValue)
    {
      if (actionReturnValue == null)
        return new EmptyResult();
      var actionResult = actionReturnValue as ActionResult;
      if (actionResult == null)
      {
        actionResult = new ContentResult()
        {
          Content = Convert.ToString(actionReturnValue, (IFormatProvider) CultureInfo.InvariantCulture)
        };
      }
      return actionResult;
    }
