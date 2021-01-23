    public IEnumerable<TEntity> GetBySpecification<TEntity>(object propertyValue, string propertyName = "name", ExpressionType operation = ExpressionType.Equal) where TEntity : class, new()
    {
        ParameterExpression par = Expression.Parameter(typeof(TEntity));
        Expression left = Expression.PropertyOrField(par, propertyName);
        Expression right = Expression.Constant(propertyValue, left.Type);
        Expression comparison;
        try
        {
            comparison = Expression.MakeBinary(operation, left, right);
        }
        catch (InvalidOperationException)
        {
            // string case, for example
            Type icomparable = typeof(IComparable<>).MakeGenericType(left.Type);
            if (!left.Type.GetInterfaces().Any(x => x == icomparable))
            {
                throw;
            }
            InterfaceMapping interfaceMap = left.Type.GetInterfaceMap(icomparable);
            int ix = Array.FindIndex(interfaceMap.InterfaceMethods, x => x.Name == "CompareTo");
            MethodInfo method = interfaceMap.TargetMethods[ix];
            // left.CompareTo(right) [operation] 0
            comparison = Expression.MakeBinary(operation, Expression.Call(left, method, right), Expression.Constant(0));
        }
        if (comparison.Type != typeof(bool))
        {
            throw new ArgumentException("operationType");
        }
        Expression<Func<TEntity, bool>> lambda = Expression.Lambda<Func<TEntity, bool>>(comparison, par);
        ISpecification<TEntity> specification = new EntityByCustomSpecification<TEntity>(lambda);
        var result = context.Set<TEntity>().Where(specification.SatisfiedBy());
        return result;
    }
