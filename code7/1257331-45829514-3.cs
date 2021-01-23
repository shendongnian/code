    // Allocate the relevant contract resolver. 
    // Options are CamelCasePropertyNamesContractResolver() or DefaultContractResolver().
    IContractResolver resolver = new DefaultContractResolver(); 
    // Get properties
    var propertyNames = resolver.PropertyNames(typeof(model));
    var fields = "&fields=" + String.Join(",", propertyNames);
