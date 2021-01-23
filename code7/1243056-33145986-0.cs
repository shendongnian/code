    public static void InjectData<T>(this T data, Dictionary<Expression<Func<T, object>>, object> pairData)
    {
        foreach (var pair in pairData)
        {
            data.SetPropertyValue(pair.Key, pair.Value);
        }
    }
    public static T SetPropertyValue<T>(this T target, Expression<Func<T, object>> memberLamda, object value)
    {
        var memberSelectorExpression = memberLamda.Body as MemberExpression;
        if (memberSelectorExpression == null)
        {
            return target;
        }
        var property = memberSelectorExpression.Member as PropertyInfo;
        if (property == null)
        {
            return target;
        }
        property.SetValue(target, value, null);
        return target;
    }
