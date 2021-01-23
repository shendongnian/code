    var namespace = routeData.Values["namespace"] as string;
    if (namespace == null)
      return base.SelectController(request);
    //see if this is in our cache
    var found = _duplicateControllerTypes.Value
      .Where(x => string.Equals(x.Name, controllerNameAsString + ControllerSuffix, StringComparison.OrdinalIgnoreCase))
      .FirstOrDefault(x => x.Namespace == namespace);
