         private static Type GetPropertyType<TClass>(Expression<Func<TClass, object>> propertyExpression)
        {
            Type type = propertyExpression.Body.Type;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = Nullable.GetUnderlyingType(type);
            }
            return type;
        }
