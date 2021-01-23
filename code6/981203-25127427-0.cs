    private static Expression GetConvertedSource(ParameterExpression sourceParameter,
                                                 PropertyInfo sourceProperty, 
                                                 TypeCode typeCode)
    {
        var sourceExpressionProperty = Expression.Property(sourceParameter,
                                                           sourceProperty);
        var changeTypeCall = Expression.Call(typeof(Convert).GetMethod("ChangeType", 
                                                               new[] { typeof(object),
                                                                typeof(TypeCode) }),
                                                                sourceExpressionProperty,
                                                                Expression.Constant(typeCode)
                                                                );
        Expression convert = Expression.Convert(changeTypeCall, 
                                                Type.GetType("System." + typeCode));
        var convertExpr = Expression.Condition(Expression.Equal(sourceExpressionProperty,
                                                Expression.Constant(null, sourceProperty.PropertyType)),
                                                Expression.Default(Type.GetType("System." + typeCode)),
                                                convert);
        return convertExpr;
    }
