    public IEnumerable<TEntity> GetBySpecification<TEntity>(object propertyValue, string propertyName = "name", ExpressionType operation = ExpressionType.Equal) where TEntity : class, new()
    {
        ParameterExpression par = Expression.Parameter(typeof(TEntity));
        Expression left = Expression.PropertyOrField(par, propertyName);
        Expression right = Expression.Constant(propertyValue);
        BinaryExpression comparison = Expression.MakeBinary(operation, left, right);
        if (comparison.Type != typeof(bool))
        {
            throw new ArgumentException("operationType");
        }
        Expression<Func<TEntity, bool>> lambda = Expression.Lambda<Func<TEntity, bool>>(comparison, par);
        ISpecification<TEntity> specification = new EntityByCustomSpecification<TEntity>(lambda);
        var result = context.CreateDbSet<TEntity>().Where(Specification.SatisfiedBy());
        return result;
    }
