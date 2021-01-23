    NameValueCollection nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
    var results = new IEnumerable<T>();
    var generalSearch = nvc["sSearch"];
    if (!string.IsNullOrWhiteSpace(generalSearch))
    {
        var generalSearchProperties = typeof(T).GetProperties();
        foreach (var currentProperty in generalSearchProperties)
        {
            Type propType = currentProperty.PropertyType;
            results.AddRange(set.Where(StaticUtility.PropertyEquals<T>(currentProperty, generalSearch, propType)));
            
        }
    }
    return results.Distinct();
