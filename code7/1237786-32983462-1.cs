          private static Type GetPropertyType<TClass>(Expression<Func<TClass, object>> propertyExpression)
        {
            var unaryExpression = propertyExpression.Body as UnaryExpression;
            if (unaryExpression == null) return propertyExpression.Body.Type;
            
            var type = unaryExpression.Operand.Type;
               
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>))
            {
                type = Nullable.GetUnderlyingType(type);
            }
            return type;
        }
