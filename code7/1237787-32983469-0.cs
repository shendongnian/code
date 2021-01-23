    static Type GetPropertyType<TObject>(Expression<Func<TObject, object>> propertyExpression)
    {
        var expression = propertyExpression.Body;
        var unaryExpression = expression as UnaryExpression;
        if (unaryExpression != null)
        {
            expression = unaryExpression.Operand;
        }
        Type type = expression.Type;
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            type = Nullable.GetUnderlyingType(type);
        }
        return type;
    }
