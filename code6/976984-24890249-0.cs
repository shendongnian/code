    Expression comparison = null;
    if (value.Type == typeof (string))
    {
        if (operation == ExpressionType.GreaterThanOrEqual ||
            operation == ExpressionType.GreaterThan ||
            operation == ExpressionType.LessThanOrEqual ||
            operation == ExpressionType.LessThan)
        {
            var method = value.Type.GetMethod("CompareTo", new[] {typeof (string)});
            var zero = Expression.Constant(0);
            var result = Expression.Call(member, method, converted);
            comparison = Expression.MakeBinary(operation, result, zero);
        }
    }
    if (comparison == null)
        comparison = Expression.MakeBinary(operation, member, converted);
    var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);
