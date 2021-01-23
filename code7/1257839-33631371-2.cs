    private static string[] GetPropertiesName<TObj, TProp>(params Expression<Func<TObj, TProp>>[] prop)
    {
        List<string> ret = new List<string>();
        foreach (var item in prop)
            ret.Add(GetPropertyName(item));
        return ret.ToArray();
    }
    private static string GetPropertyName<TObj, TProp>(Expression<Func<TObj, TProp>> prop)
    {
        var expression = prop.Body as MemberExpression;
    
        if (expression != null)
        {
            var property = expression.Member as PropertyInfo;
    
            if (property != null)
            {
                return property.Name;
            }
        }
    
        return string.Empty;
    }
