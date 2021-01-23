    public virtual Expression<Func<TSubclass, object>> UpdateCriterion()
    {
        var param = Expression.Parameter(typeof(TSubclass));
        var body = Expression.Convert(Expression.Property(param, "ID"), typeof(object));
     
        return Expression.Lambda<Func<TSubclass, object>>(body, param);
    }
