    NameValueCollection nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
    
    // Container for filter expression
    BinaryExpression filter = null;
    var generalSearch = nvc["sSearch"];
    if (!string.IsNullOrWhiteSpace(generalSearch)) {
        var generalSearchProperties = typeof(T).GetProperties();
        foreach (var currentProperty in generalSearchProperties) {
            Type propType = currentProperty.PropertyType;
    
            if (filter == null) {
                // Start with first filter expression
                filter = StaticUtility.PropertyEquals<T>(currentProperty, generalSearch, propType);
            } else {
                // Add another filter using OR
                BinaryExpression other = StaticUtility.PropertyEquals<T>(currentProperty, generalSearch, propType);
                filter = BinaryExpression.OrElse(filter, other);
            }
        }
    }
    
    // Add actual filter to query
    set = set.Where(filter);
