    var visitor = new ReplaceMethodCallVisitor(
        diffDaysMethod,
        args => Expression.Convert(
            Expression.Property(
                Expression.Property(Expression.Subtract(args[0], args[1]), "Value"),
                "Days"),
            typeof(int?)));
    var replacedExpression = visitor.Visit(GetDataRequiredExpression());
