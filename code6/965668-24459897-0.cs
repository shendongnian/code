    public Expression<Func<T, bool>> constructMethodCallPredicate<T>()
    {
        var type = typeof(T);
        if (type.GetProperty(this.fieldName) == null && type.GetField(this.fieldName) == null)
            throw new MissingMemberException(type.Name, this.fieldName);
        MethodInfo method;
        if (!methodMap.TryGetValue(this.selectionComparison, out method))
            throw new ArgumentOutOfRangeException("selectionComparison", this.selectionComparison, "Invalid filter operation");
        var parameter = Expression.Parameter(type);
        var member = Expression.PropertyOrField(parameter, this.fieldName);
        var value = (this.fieldValue == null) ? Expression.Constant(null) : Expression.Constant(this.fieldValue, this.fieldValue.GetType());
        try
        {
            var converted = (value.Type != member.Type)
                ? (Expression)Expression.Convert(value, member.Type)
                : (Expression)value;
            var methodExpression = Expression.Call(member, method, converted);
            var lambda = Expression.Lambda<Func<T, bool>>(methodExpression, parameter);
            return lambda;
        }
        catch (Exception)
        {
            throw new InvalidOperationException(
                String.Format("Cannot convert value \"{0}\" of type \"{1}\" to field \"{2}\" of type \"{3}\"", this.fieldValue,
                    value.Type, this.fieldName, member.Type));
        }
    }
    private static readonly Dictionary<SelectionComparison, MethodInfo> methodMap =
        new Dictionary<SelectionComparison, MethodInfo>
        {
            { SelectionComparison.Contains, typeof(string).GetMethod("Contains", new[] { typeof(string) }) },
            { SelectionComparison.StartsWith, typeof(string).GetMethod("StartsWith", new[] { typeof(string) }) },
            { SelectionComparison.EndsWith, typeof(string).GetMethod("EndsWith", new[] { typeof(string) }) },
        };
    public enum SelectionComparison
    {
        Equal,
        NotEqual,
        LessThan,
        LessThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual,
        Contains,
        StartsWith,
        EndsWith,
    };
