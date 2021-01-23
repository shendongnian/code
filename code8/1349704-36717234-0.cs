    ValueProviderCollection valueProviderCollection = filterContext.Controller.ValueProvider as ValueProviderCollection;
    if (valueProviderCollection == null)
    throw new NullReferenceException("filterContext.Controller.ValueProvider as ValueProviderCollection");
    
    valueProviderCollection.Insert(0, new EncryptedQueryStringValuesProvider(filterContext.RequestContext, filterContext.ActionDescriptor));
