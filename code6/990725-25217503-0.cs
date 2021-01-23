    var matchExpression
        = identifyingProperties.Select(
            pi => Expression.Equal(
                Expression.Property(parameter, pi.Single()),
                Expression.Constant(pi.Last().GetValue(entity, null))))
