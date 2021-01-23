    //the cache does not contain this controller because it's most likely a duplicate, 
    // so we need to sort this out ourselves and we can only do that if the namespace token
    // is formatted correctly.
    var namespaces = routeData.Route.DataTokens["Namespaces"] as IEnumerable<string>;
    if (namespaces == null)
      return base.SelectController(request);
    //see if this is in our cache
    var found = _duplicateControllerTypes.Value
      .Where(x => string.Equals(x.Name, controllerNameAsString + ControllerSuffix, StringComparison.OrdinalIgnoreCase))
      .FirstOrDefault(x => namespaces.Contains(x.Namespace));
