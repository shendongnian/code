    public static RouteValueDictionary Merge(params object[] routeValuesObjects)
    {
        var result = new RouteValueDictionary();
        foreach (var routeValues in routeValuesObjects)
            foreach (var item in new RouteValueDictionary(routeValues))
                result[item.Key] = item.Value;
        return result;
    }
