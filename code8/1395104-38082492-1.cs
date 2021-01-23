    var method = expression as MethodCallExpression;
    if (method != null && method.Method.Name == "Select")
    {
        // handle projections
        var lambda = ((UnaryExpression)method.Arguments[1]).Operand as LambdaExpression;
        if (lambda != null)
        {
            var returnType = lambda.ReturnType;
            var selectMethod = typeof(Queryable).GetMethods().First(m => m.Name == "Select");
            var typedGeneric = selectMethod.MakeGenericMethod(typeof(T), returnType);
            var result = typedGeneric.Invoke(null, new object[] { viewSet.ToList().AsQueryable(), lambda }) as IEnumerable;
            return result;
        }
    }
