    var condition =
        Expression.Lambda<Func<object,bool>>(
            Expression.Equal(
                Expression.Property(parameter, paramName),
                Expression.Constant(typedValue, paramType)
            ),
            parameter
        );
