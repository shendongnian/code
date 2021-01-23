    public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute {
        var attrType = typeof(T);
        var property = instance.GetType().GetProperty(propertyName);
        return (T)property.GetCustomAttributes(attrType, false).First();
    }
    public static T GetAttributeFrom<T, U>(this object instance, Expression<Func<U>> propertyExpression) where T : Attribute {
        var attrType = typeof(T);
        var property = instance.GetType().GetProperty(GetPropertyNameFromLambdaExpression<U>(propertyExpression));
        return (T)property.GetCustomAttributes(attrType, false).First();
    }
    public static string GetPropertyNameFromLambdaExpression<U>(Expression<Func<U>> propertyAsExpression) {
        var memberExpression = propertyAsExpression.Body as MemberExpression;
        var propertyInfo = memberExpression.Member as PropertyInfo;
        if (memberExpression != null && propertyInfo != null) {
            return memberExpression.Member.Name;
        }
        throw new ArgumentException(propertyAsExpression.ToString());
    }
